using NUnit.Framework;
using System;
namespace EasyEqual
{
    [TestFixture()]
    public class Seed_Tests
    {
        private Seed actualSeed;
        private Seed expectedSeed;
        private Seed shallowSeed;
        private Seed fakeSeed; 

        public Compare<Seed> compare { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            this.actualSeed = new Seed(foo: new Foo(6, "Equality", false), edible: true); 
            this.expectedSeed = new Seed(foo: new Foo(6, "Equality", false), edible: true);

            this.shallowSeed = new Seed(foo: new Foo(6, "No Equality", false), edible: true);

            this.fakeSeed = new Seed(foo: new Foo(7, "No Equality", true), edible: false);

			this.compare = new Compare<Seed>(); 

		}
        [Test]
        [Category("Seed")]
        public void DeepEqual()
        {
            this.compare.SetUp(this.actualSeed, this.expectedSeed);

            this.compare.ShouldEqual(deepEquality: true);
        }
    }
}
