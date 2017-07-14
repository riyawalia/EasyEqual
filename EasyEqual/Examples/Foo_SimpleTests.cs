﻿﻿using NUnit.Framework;
using System;
namespace EasyEqual
{
    [TestFixture]
    public class Foo_SimpleTests
    {
        protected Foo actualFoo;
        protected Foo expectedFoo;
        protected Foo fakeFoo;

        protected Compare<Foo> compare; 

        [OneTimeSetUp]
        public void SetUp()
        {
            this.compare = new Compare<Foo>(); 

            this.actualFoo = new Foo(5, "Riya", true);
            this.expectedFoo = new Foo(5, "Riya", true);
            this.fakeFoo = new Foo(5, "Riya", false);

        }
        [Test]
        [Category("Foo")]
        // different instances of Foo, equal in value  
        public void EqualValues()
        {
            this.compare.Set(actualFoo, expectedFoo);

            Assert.IsTrue(this.compare.AreEqual(), "Different instances of same values");
        }
        [Test]
        [Category("Foo")]
        public void UnequalValues()
        {
            this.compare.Set(actualFoo, fakeFoo);

			Assert.IsFalse(this.compare.AreEqual(), "Different instances of different values");
		}

        [Test]
        [Category("Foo")]
        public void EqualNullValues()
        {
            this.compare.Set(default(Foo), default(Foo));

            Assert.IsTrue(this.compare.AreEqual(), "Null references"); 
        }

        [Test]
        [Category("Foo")]
        public void UnequalNullValues()
        {
            this.compare.Set(default(Foo), this.fakeFoo);

            Assert.IsFalse(this.compare.AreEqual()); 
        }

        [Test]
        [Category("Foo")]
        public void DeepEqual()
        {
            this.compare.Set(this.actualFoo, this.expectedFoo); 

            Assert.IsTrue(this.compare.AreEqual(DeepEquality: true)); 
        }

        [Test]
        [Category("Foo")]
        public void EqualQuick()
        {
            Assert.IsTrue(Compare<Foo>.AreEqual(this.actualFoo, this.expectedFoo)); 
        }

    }
}
