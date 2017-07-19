using System;
using System.Diagnostics;
using NUnit.Framework;

namespace EasyEqual
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // TODO: 
            // create objects 
            // simple object 
            // hierarchy object 
            // complex nested objects
            // assert stuff is true for both deep compare and shallow compare for all  
            // equal values, unequal values, same instances, different instances, demonstrate type safety as well 

            bool TRACE = false;
            if (TRACE)
            {
				var compare = new Compare<Foo>();

				var actualFoo = new Foo(5, "Riya", false);
				var expectedFoo = new Foo(5, "Riya", true);

				compare.SetUp(actualFoo, expectedFoo);
			}

            //TODO: goals for next commit -> ignore this file, deepEquality actually executed 
            // next to next commit -> define your own assertion class, differences as strings, exec differences 
            // next to next to next commit -> establish program examples, partial class definitions etc 
        }
    }
}
