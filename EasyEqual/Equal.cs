using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq; 

namespace EasyEqual
{
    public class Compare<T>
    {
        T actual;
        T expected;

        public Compare()
        {

        }
        public Compare(T actual, T expected)
        {
            this.Set(actual, expected); 
        }

        public HashSet<string> GetFields(T compared)
        {
            // a list of all fields of object instances including public and non public members 
            var comparedFields = compared.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToList();

            // remove fields of collection type
            comparedFields.RemoveAll(field => field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(ICollection<>));

            // fields are parsed intro strings and contained in a hash set 
            // null values are parsed into empty strings
            var comparedSet = new HashSet<string>(comparedFields.Select(field => (field.GetValue(compared) ?? "").ToString()));

            comparedSet.ToList().ForEach(s => Console.WriteLine(s));

            Console.WriteLine("nothing?"); 

            return comparedSet;
        }

        /// <summary>
        /// Checks shallow equality of two objects 
        /// </summary>
        /// <returns><c>true</c>, if objects are equal, <c>false</c> otherwise </returns>
        public bool AreEqual()
        {
            var nullValues = ((this.actual == null) ? 1 : 0) + ((this.expected == null) ? 1 : 0);
            // if one of the objects is null
            if (nullValues > 0)
            {
                // true if and only if both objects are null
                return nullValues == 2;
            }

            var actualSet = this.GetFields(this.actual);
            var expectedSet = this.GetFields(this.expected);

            return actualSet.SetEquals(expectedSet);
        }
        /// <summary>
        ///  Checks deep equality of two objects using recursion on non-primitive fields. 
        /// </summary>
        /// <returns><c>true</c>, if objects are equal <c>false</c> otherwise.</returns>
        /// <param name="DeepEquality">If set to <c>true</c> deep equality.</param>
        public bool AreEqual(bool DeepEquality)
        {
            if (!DeepEquality)
            {
                return this.AreEqual();
            }

            return true;
        }

        public static bool AreEqual(T actual, T expected)
        {
            var compare = new Compare<T>(actual, expected);

            return compare.AreEqual(); 
        }
        /// <summary>
        /// Gets the differences in values of the two object instances being compared.
        /// </summary>
        /// <returns>A list of two dictionaries which contain [fieldName, valueInString] pairs</returns>
        public List<Dictionary<string, string>> Differences()
        {
            var expectedValues = new Dictionary<string, string>();
            var actualValues = new Dictionary<string, string>();

            return new List<Dictionary<string, string>> { expectedValues, actualValues };

        }

        public void Set(T actual, T expected)
        {
            this.actual = actual;
            this.expected = expected;
        }
    }
}
