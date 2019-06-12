﻿using System;
using NUnit.Framework;
using EasyEqual.CompareNS;
using EasyEqual.Tests.ComplexTypeTests.Types; 

namespace EasyEqual.Tests.ComplexTypeTests.DefinedComplexFieldsTests
{
    [TestFixture()]
    public class DefinedComplexFieldsType : IEasyEqualTest
    {
		public PrimitiveFieldsOnlyType actualField = new PrimitiveFieldsOnlyType(true, 55);
		public PrimitiveFieldsOnlyType expectedField = new PrimitiveFieldsOnlyType(true, 55);
		public PrimitiveFieldsOnlyType unequalField = new PrimitiveFieldsOnlyType(false, 100);

        public int actualInt = 100;
        public int expectedInt = 100;
        public int unequalInt = 200; 
		
        [Test]
        public void AreEqual_DifferentObjectTest()
        {
            var actual = new NestedObjectType(actualField, actualInt);
            var expected = new NestedObjectType(expectedField, expectedInt); 

			var result = Compare.AreEqual(actual, expected);
			Assert.IsTrue(result);
        }

        [Test]
        public void AreEqual_SameObjectTest()
        {
			var actual = new NestedObjectType(actualField, actualInt);

			var result = Compare.AreEqual(actual, actual);
			Assert.IsTrue(result); 
        }

        [Test]
        public void AreEqual_ValuesAreDefaultTest()
        {
            var result = Compare.AreEqual(default(NestedObjectType), default(NestedObjectType));
			Assert.IsTrue(result);
		}

        [Test]
        public void AreEqual_ValuesAreNullTest()
        {
			var result = Compare.AreEqual(null, null);
			Assert.IsTrue(result);
        }

        [Test]
        public void AreUnequalTest()
        {
			var actual = new NestedObjectType(actualField, actualInt);
            var unequal = new NestedObjectType(unequalField, unequalInt);

			var result = Compare.AreEqual(actual, unequal);
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ActualValueIsDefaultTest()
        {
			var expected = new NestedObjectType(expectedField, expectedInt);

            var result = Compare.AreEqual(default(NestedObjectType), expected);
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ActualValueIsNullTest()
        {
			var expected = new NestedObjectType(expectedField, expectedInt);

			var result = Compare.AreEqual(null, expected);
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ExpectedValueIsDefaultTest()
        {
            var actual = new NestedObjectType(actualField, actualInt);

            var result = Compare.AreEqual(actual, default(NestedObjectType));
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ExpectedValueIsNullTest()
        {
			var actual = new NestedObjectType(actualField, actualInt);

			var result = Compare.AreEqual(actual, null);
			Assert.IsFalse(result);
        }
    }
}
