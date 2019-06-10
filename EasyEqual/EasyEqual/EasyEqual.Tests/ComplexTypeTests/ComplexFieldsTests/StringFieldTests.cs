﻿using System;
using NUnit.Framework;
using EasyEqual.Compare;
using EasyEqual.Tests.ComplexTypeTests.Types;

namespace EasyEqual.Tests.ComplexTypeTests.ComplexFieldsTests
{
    [TestFixture()]
    public class StringFieldTests : IEasyEqualTest<StringFieldTests>
    {
        
        [Test]
        public void AreEqual_DifferentObjectTest()
        {
            var actual = new StringFieldType("test"); 
            var expected = new StringFieldType("test");

			var result = Compare<StringFieldType>.AreEqual(actual, expected);
			Assert.IsTrue(result);
        }

        [Test]
        public void AreEqual_SameObjectTest()
        {
			var actual = new StringFieldType("test");

			var result = Compare<StringFieldType>.AreEqual(actual, actual);
			Assert.IsTrue(result);
        }

        [Test]
        public void AreEqual_ValuesAreDefaultTest()
        {
			var result = Compare<StringFieldType>.AreEqual(default(StringFieldType), default(StringFieldType));
			Assert.IsTrue(result);
        }

        [Test]
        public void AreEqual_ValuesAreNullTest()
        {
			var result = Compare<StringFieldType>.AreEqual(null, null);
			Assert.IsTrue(result);
        }

        [Test]
        public void AreUnequalTest()
        {
			var actual = new StringFieldType("test");
			var expected = new StringFieldType("unequal");

			var result = Compare<StringFieldType>.AreEqual(actual, expected);
            Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ActualValueIsDefaultTest()
        {
			var expected = new StringFieldType("unequal");

            var result = Compare<StringFieldType>.AreEqual(default(StringFieldType), expected);
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ActualValueIsNullTest()
        {
			var expected = new StringFieldType("unequal");

			var result = Compare<StringFieldType>.AreEqual(null, expected);
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ExpectedValueIsDefaultTest()
        {
			var actual = new StringFieldType("unequal");

			var result = Compare<StringFieldType>.AreEqual(actual, default(StringFieldType));
			Assert.IsFalse(result);
        }

        [Test]
        public void AreUnequal_ExpectedValueIsNullTest()
        {
			var actual = new StringFieldType("unequal");

			var result = Compare<StringFieldType>.AreEqual(actual, null);
			Assert.IsFalse(result);
        }
    }
}
