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
            var allFields = GetAllFieldTypes(objectToConvert);
            var primitiveFields = GetPrimitiveFieldInfo(allFields);
            var primitiveKeys = GetKeySet(primitiveFields);

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
            allFieldTypes.RemoveAll(field => !field.GetType().IsPrimitive);
            return new HashSet<FieldInfo>(allFieldTypes); 
        }

        private static HashSet<Type> GetComplexFields(List<FieldInfo> allFieldTypes) { throw new NotImplementedException(); }
        private static HashSet<string> GetKeySet(HashSet<FieldInfo> fields) { throw new NotImplementedException(); }

    }
}


