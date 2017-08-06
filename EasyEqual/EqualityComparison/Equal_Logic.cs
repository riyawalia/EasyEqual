using System;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace EasyEqual
{
    public partial class Compare<T>
    {
        protected T actual;
        protected T expected;

        private HashSet<string> actualSet;
        private HashSet<string> expectedSet;


        public Compare()
        {

        }
        public Compare(T actual, T expected)
        {
            this.SetUp(actual, expected);
        }

        private bool HasPrimitiveFieldsOnly()
        {
            var comparedFields = this.actual.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToList();

            foreach (FieldInfo field in comparedFields) 
            {
				if (!field.GetType().IsPrimitive)
				{
					return false;
				}
            }
            return true; 
        }

        private HashSet<string> GetFields(T compared)
        {
            // a list of all fields of the object including public, non public members and instances
            var comparedFields = compared.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToList();

            // remove fields of collection type and non primitive type
            comparedFields.RemoveAll(field => !field.GetType().IsPrimitive || (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(ICollection<>)));

            // fields are parsed into strings and contained in a hash set 
            // null values are parsed into empty strings
            var comparedSet = new HashSet<string>(comparedFields.Select(field => (field.GetValue(compared) ?? "").ToString()));

            return comparedSet;
        }

        private List<string> GetComplexTypes(T compared)
        {
            var comparedFields = compared.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToList();

            comparedFields.RemoveAll(field => field.GetType().IsPrimitive || (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(ICollection<>)));

            var complexTypes = comparedFields.Select(field => field.GetType().ToString()).ToList();

            return complexTypes; 
        }

        private void DeepEqualityForCollections()
        {
            // TODO: do stuff 
        }

        #region EqualityChecks
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

            this.actualSet = this.GetFields(this.actual);
            this.expectedSet = this.GetFields(this.expected);

            return actualSet.SetEquals(expectedSet);
        }

        /// <summary>
        ///  Checks deep equality of two objects by including values of non-primitive fields. 
        /// </summary>
        /// <returns><c>true</c>, if objects are equal <c>false</c> otherwise.</returns>
        /// <param name="deepEquality">If set to <c>true</c> deep equality.</param>
        public bool AreEqual(bool deepEquality)
        {
            var shallowEquals = this.AreEqual();

            if (!deepEquality || !shallowEquals || this.HasPrimitiveFieldsOnly())
            {
                return shallowEquals;
            }

            var deepEquals = true;

            var complexTypes = this.GetComplexTypes(this.actual);
            var listOfEquality = new List<bool>(); 

            foreach(string complexType in complexTypes)
            {
                // getting the objects 
                Object actualComplex;
                Object expectedComplex; 

                var complexProperty = this.actual.GetType().GetProperty(complexType);
                var type = complexProperty.PropertyType; 
                //var expectedProperty = this.expected.GetType().GetProperty(complexType); 

                actualComplex = complexProperty.GetValue(actual);
                expectedComplex = complexProperty.GetValue(expected);

                dynamic compareComplex = Activator.CreateInstance(typeof(Compare<>).MakeGenericType(type));

                compareComplex.SetUp(actualComplex, expectedComplex);

                bool areEqual = compareComplex.AreEqual(deepEquality: true);

                listOfEquality.Add(areEqual); 
            }

            listOfEquality.ForEach(areEqual =>
            {
                deepEquals = (areEqual == false) ? false : deepEquals;
			}); 

            //TODO:

            // as soon as something is false, exit loop 

            // make a list of complex data types 
            // include iCollections 
            // put in a loop for the list, recur on each, recur and loop on iCollections 

            // shallowEquals must be true 
            return deepEquals;
        }

        public bool AreNotEqual(bool deepEquality)
        {
            return !this.AreEqual(deepEquality: deepEquality); 
        }

        #endregion

        #region EqualityAssertions



        public void ShouldEqual(bool deepEquality)
        {
            var isEqual = this.AreEqual(deepEquality: deepEquality);

            if (isEqual == false)
            {
                throw new Exception("Assertion failed");
            }
        }

        public void ShouldNotEqual(bool deepEquality)
        {
            var isEqual = this.AreEqual(deepEquality: deepEquality);

            if (isEqual == true)
            {
                throw new Exception("Assertion failed");
            }
        }

        #endregion

        #region Details
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

        public void SetUp(T actual, T expected)
        {
            this.actual = actual;
            this.expected = expected;
        }
        #endregion
    }
}
