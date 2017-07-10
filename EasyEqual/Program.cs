using System;
using System.Diagnostics;
using NUnit.Framework;

namespace EasyEqual
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // create objects 
                // simple object 
                // hierarchy object 
                // complex nested objects 

            // assert stuff is true for both deep compare and shallow compare for all  
            var actualFoo = new Foo(5, "Riya");
            var expectedFoo = new Foo(5, "Riya");
            var fakeFoo = new Foo(10, "Riya");

            var compareTrue = new Compare<Foo>(actualFoo, expectedFoo);
            var compareFalse = new Compare<Foo>(actualFoo, fakeFoo); 

            Debug.Assert(compareTrue.AreEqual() == true);
            Debug.Assert(compareFalse.AreEqual() == false); 


        }
    }
}
