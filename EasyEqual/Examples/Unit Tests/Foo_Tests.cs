﻿﻿using NUnit.Framework; 
using System;

namespace EasyEqual
{
    [TestFixture]
    public class Foo_Tests : ITestInterface<Foo>
    {
        protected Foo actualFoo;
        protected Foo expectedFoo;
        protected Foo fakeFoo;

        public Compare<Foo> compare { get; set; }

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
            this.compare.SetUp(actualFoo, expectedFoo);

            Assert.IsTrue(this.compare.AreEqual(), "Different instances of same values");
        }
        [Test]
        [Category("Foo")]
        public void UnequalValues()
        {
            this.compare.SetUp(actualFoo, fakeFoo);

			Assert.IsFalse(this.compare.AreEqual(), "Different instances of different values");
		}

        [Test]
        [Category("Foo")]
        public void EqualNullValues()
        {
            this.compare.SetUp(default(Foo), default(Foo));

            Assert.IsTrue(this.compare.AreEqual(), "Null references"); 
        }

        [Test]
        [Category("Foo")]
        public void UnequalNullValues()
        {
            this.compare.SetUp(default(Foo), this.fakeFoo);

            this.compare.ShouldNotEqual(); 
        }

        [Test]
        [Category("Foo")]
        public void DeepEqual()
        {
            this.compare.SetUp(this.actualFoo, this.expectedFoo); 

            this.compare.ShouldEqual(deepEquality: true); 
        }

        [Test]
        [Category("Foo")]
        public void DeepUnequal()
        {
            this.compare.SetUp(this.actualFoo, this.fakeFoo);

            this.compare.ShouldNotEqual(deepEquality: true); 
        }

        [Test]
        [Category("Foo")]
        public void EqualQuick()
        {
            Compare<Foo>.ShouldEqual(this.actualFoo, this.expectedFoo); 
        }

        [Test]
        [Category("Foo")]
        public void EqualQuickDeep()
        {
            Compare<Foo>.ShouldNotEqual(this.actualFoo, this.fakeFoo, deepEquality: true); 
        }

    }
}
