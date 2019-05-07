using NUnit.Framework;
using System;
using EasyEqual.Compare;

namespace EasyEqual.Tests.ComplexTypeTests.PrimitiveFieldsOnlyTests
{
    [TestFixture()]
    public class PrimitiveFieldsOnly : IEasyEqualTest<PrimitiveFieldsOnly>
    {
        public void AreEqual_DifferentObjectTest()
        {
			var actual = new PrimitiveFieldsOnlyType(true, 55);
			var expected = new PrimitiveFieldsOnlyType(true, 55);

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_SameObjectTest()
        {
            var test = new PrimitiveFieldsOnlyType(true, 55);
			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(test, test);
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_ValuesAreDefaultTest()
        {
            var actual = default(PrimitiveFieldsOnlyType); 
			var expected = default(PrimitiveFieldsOnlyType);

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreEqual_ValuesAreNullTest()
        {
			PrimitiveFieldsOnlyType actual = null;
			PrimitiveFieldsOnlyType expected = null;

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsTrue(result);
        }

        [Test()]
        public void AreUnequalTest()
        {
			var actual = new PrimitiveFieldsOnlyType(true, 55);
			var expected = new PrimitiveFieldsOnlyType(false, 110);

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }


		[Test()]
        public void AreUnequal_SingleFieldIsEqualTest()
		{
			var actual = new PrimitiveFieldsOnlyType(true, 55);
			var expected = new PrimitiveFieldsOnlyType(true, 110);

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsFalse(result);
		}

        [Test()]
        public void AreUnequal_ActualValueIsDefaultTest()
        {
			var actual = default(PrimitiveFieldsOnlyType);
			var expected = new PrimitiveFieldsOnlyType(true, 55);

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ActualValueIsNullTest()
        {
            PrimitiveFieldsOnlyType actual = null;
			var expected = new PrimitiveFieldsOnlyType(true, 55);

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ExpectedValueIsDefaultTest()
        {
			var actual = new PrimitiveFieldsOnlyType(true, 55);
			var expected = default(PrimitiveFieldsOnlyType); 

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }

        [Test()]
        public void AreUnequal_ExpectedValueIsNullTest()
        {
			var actual = new PrimitiveFieldsOnlyType(true, 55); 
			PrimitiveFieldsOnlyType expected = null;

			var result = Compare<PrimitiveFieldsOnlyType>.AreEqual(actual, expected);
			Assert.IsFalse(result);
        }
    }
}
