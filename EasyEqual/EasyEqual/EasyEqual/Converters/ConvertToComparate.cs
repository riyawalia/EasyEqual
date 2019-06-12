using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace EasyEqual.Converters
{
    internal static class ConvertToComparate<T>
    {
        public static Comparate Convert(object objectToConvert)
        {
            if (objectToConvert.GetType().IsPrimitive)
            {
                return ConvertPrimitiveType(objectToConvert);
			}

            return ConvertComplexType(objectToConvert); 
                
        }

        private static Comparate ConvertPrimitiveType(object objectToConvert)
        {
            var key = new List<string>() { MakePrimitiveKey(objectToConvert) }; 

            var comparate = new Comparate(new HashSet<string>(key));
            return comparate; 
        }

		private static Comparate ConvertComplexType(object objectToConvert)
		{
            var allFields = GetAllFieldTypes(objectToConvert);
            var primitiveKeys = ConvertPrimitiveFields(allFields, objectToConvert);
            var complexFields = GetComplexFieldInfo(allFields);

            if (complexFields.Count() == 0)
                return new Comparate(primitiveKeys);

            var complexComparate = new List<Comparate>();
            foreach (var fieldInfo in complexFields) {
                var fieldValue = fieldInfo.GetValue(objectToConvert);
                var fieldComparate = Convert(fieldValue);
                complexComparate.Add(fieldComparate); 
                
            }

            return new Comparate(primitiveKeys, complexComparate);
		}




        private static HashSet<string> ConvertPrimitiveFields(List<FieldInfo> allFields, object objectToConvert) {
			
			var primitiveFields = GetPrimitiveFieldInfo(allFields);
			var primitiveKeys = GetKeySet(primitiveFields, objectToConvert);

            return primitiveKeys; 
        }

        private static List<FieldInfo> GetAllFieldTypes(object objectToConvert) 
        {
			var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var fieldTypes = objectToConvert.GetType().GetFields(bindingFlags);
            return fieldTypes.ToList(); 
        }

        private static HashSet<FieldInfo> GetPrimitiveFieldInfo(List<FieldInfo> allFieldTypes) 
        {
            // gettype() is of base type reflection - instead using fieldtype
            var primitiveFieldInfo = new List<FieldInfo>(allFieldTypes);
			primitiveFieldInfo.RemoveAll(field => !field.FieldType.IsPrimitive);
            return new HashSet<FieldInfo>(primitiveFieldInfo); 
        }

        private static HashSet<FieldInfo> GetComplexFieldInfo(List<FieldInfo> allFieldTypes) 
        {
            var complexFieldInfo = new List<FieldInfo> (allFieldTypes); 
            complexFieldInfo.RemoveAll(field => field.FieldType.IsPrimitive);
            return new HashSet<FieldInfo>(complexFieldInfo); 
        }

        private static HashSet<string> GetKeySet(HashSet<FieldInfo> fields, object objectToConvert) 
        {
            var keySet = new HashSet<string>(fields.Select(field => MakeFieldKey(field, objectToConvert)).ToList());
            return keySet; 
        }

        private static string MakePrimitiveKey(object primitiveObject)
        {
            return primitiveObject.GetType() + "_" + primitiveObject; 
        }

        private static string MakeFieldKey(FieldInfo field, object objectToConvert)
        {
            var key = field.GetType() + "_" + field.GetValue(objectToConvert);
            return key; 
        }

    }
}


