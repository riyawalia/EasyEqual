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

				compare.Set(actualFoo, expectedFoo);
			}
        }
    }
}
