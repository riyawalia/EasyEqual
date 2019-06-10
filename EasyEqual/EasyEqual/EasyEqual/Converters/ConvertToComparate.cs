using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace EasyEqual.Converters
{
    internal static class ConvertToComparate<T>
    {
        public static Comparate Convert(T objectToConvert)
        {
            if (objectToConvert.GetType().IsPrimitive)
            {
                return ConvertPrimitive(objectToConvert);
			}

            return ConvertComplex(objectToConvert); 
                
        }

        private static Comparate ConvertPrimitive(T objectToConvert)
        {
            var key = new List<string>() { MakePrimitiveKey(objectToConvert) }; 

            var comparate = new Comparate(new HashSet<string>(key));
            return comparate; 
        }

		private static Comparate ConvertComplex(T objectToConvert)
		{
			var allFields = GetAllFieldTypes(objectToConvert);
			var primitiveFields = GetPrimitiveFieldInfo(allFields);
			var primitiveKeys = GetKeySet(primitiveFields, objectToConvert);

			var comparate = new Comparate(primitiveKeys);
			return comparate;
		}

        private static List<FieldInfo> GetAllFieldTypes(T objectToConvert) 
        {
			var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var fieldTypes = objectToConvert.GetType().GetFields(bindingFlags);
            return fieldTypes.ToList(); 
        }

        private static HashSet<FieldInfo> GetPrimitiveFieldInfo(List<FieldInfo> allFieldTypes) 
        {
            // gettype() is of base type reflection - instead using fieldtype
            allFieldTypes.RemoveAll(field => !field.FieldType.IsPrimitive);
            return new HashSet<FieldInfo>(allFieldTypes); 
        }

        private static HashSet<Type> GetComplexFields(List<FieldInfo> allFieldTypes) { throw new NotImplementedException(); }

        private static HashSet<string> GetKeySet(HashSet<FieldInfo> fields, T objectToConvert) 
        {
            var keySet = new HashSet<string>(fields.Select(field => MakeFieldKey(field, objectToConvert)).ToList());
            return keySet; 
        }

        private static string MakePrimitiveKey(T primitiveObject)
        {
            return primitiveObject.GetType() + "_" + primitiveObject; 
        }

        private static string MakeFieldKey(FieldInfo field, T objectToConvert)
        {
            var key = field.GetType() + "_" + field.GetValue(objectToConvert);
            return key; 
        }

    }
}


