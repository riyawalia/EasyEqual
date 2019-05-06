using NUnit.Framework;
using System;
using EasyEqual.Compare;

namespace EasyEqual.Tests.PrimitiveTypeTests
{
    [TestFixture()]
    public class PrimitiveTypeTests: IEasyEqualTest<string>
    {

        [Test()]
        public void AreEqualTest()
        {
            var testValue = "Test";

            var result = Compare<string>.AreEqual(testValue, testValue); 
            Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_ValuesAreDefaultTest()
        {
            var testValue = String.Empty;

			var result = Compare<string>.AreEqual(testValue, testValue);
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_ValuesAreNullTest()
        {
            string testValue =  null; 
			var result = Compare<string>.AreEqual(testValue, testValue);
			Assert.IsTrue(result); 
        }

        [Test()]
        public void AreUnequalTest()
        {
            var actual = "Test";
            var expected = "Test1";

            var result = Compare<string>.AreEqual(actual, expected);
			Assert.IsFalse(result);
		}

        [Test()]
        public void AreUnequal_ActualValueIsDefaultTest()
        {
            var actual = String.Empty;
			var expected = "Test";

			var result = Compare<string>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ActualValueIsNullTest()
        {
			string actual = null;
			var expected = "Test";

			var result = Compare<string>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ExpectedValueIsDefaultTest()
        {
			var actual = "Test";
			var expected = String.Empty;

			var result = Compare<string>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ExpectedValueIsNullTest()
        {
			var actual = "Test";
			string expected = null;

			var result = Compare<string>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }
    }
}
