using NUnit.Framework;
using System;
using EasyEqual.CompareNS;

namespace EasyEqual.Tests.PrimitiveTypeTests
{
    [TestFixture()]
    public class BooleanTypeTests: IEasyEqualTest
    {
        [Test()]
        public void AreEqual_DifferentObjectTest()
        {
			var actual = true;
            var expected = true;

			var result = Compare.AreEqual(actual, expected); 
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_SameObjectTest()
        { 
            var testValue = true; 

            var result = Compare.AreEqual(testValue, testValue); 
            Assert.IsTrue(result);
        }
         
        [Test()]
        public void AreEqual_ValuesAreDefaultTest()
        {
            var testValue = default(bool?);

			var result = Compare.AreEqual(testValue, testValue);
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_ValuesAreNullTest()
        {
            bool? testValue =  null; 
			var result = Compare.AreEqual(testValue, testValue);
			Assert.IsTrue(result); 
        }

        [Test()]
        public void AreUnequalTest()
        {
            var actual = true;
            var expected = false;

            var result = Compare.AreEqual(actual, expected);
			Assert.IsFalse(result);
		}

        [Test()]
        public void AreUnequal_ActualValueIsDefaultTest()
        {
            var actual = default(bool?);
			var expected = true;

			var result = Compare.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ActualValueIsNullTest()
        {
			bool? actual = null;
			var expected = true;

			var result = Compare.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ExpectedValueIsDefaultTest()
        {
			var actual = true;
            bool? expected = default(bool?);

			var result = Compare.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ExpectedValueIsNullTest()
        {
			var actual = true;
			bool? expected = null;

			var result = Compare.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }
    }
}
