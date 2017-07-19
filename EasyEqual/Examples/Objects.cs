﻿using System;
using System.Collections.Generic; 

//TODO: make 1 or 2 partial definitions so that you can define some of their methods as examples in "Programs"
namespace EasyEqual
{
    /// <summary>
    /// A simple class with primitive fields 
    /// </summary>
    public class Foo
    {
        public int a;
        public string b;

        private bool valid; 

        public Foo()
        {
            
        }
        public Foo(int a, string b)
        {
            this.a = a;
            this.b = b; 
        }
        public Foo(int a , string b, bool valid)
        {
            this.a = a;
            this.b = b;
            this.valid = valid; 
        }
    }

    /// <summary>
    /// A nested class example 
    /// </summary>
    public class Seed : Food
    {
        public Foo foo; 
        public Seed()
        {
            this.foo = new Foo(); 
        }
    }

	/// <summary>
	/// A complex and nested class example
	/// </summary>
	public class Fruit : Food
    {
        public ICollection<Seed> listOfSeeds; // instantiate list 
        public Fruit()
        {
            
        }
    }

	/// <summary>
	/// A complex class example 
	/// </summary>
	public class Food
    {
        public bool perishable;
        public ICollection<Foo> listOfFoo; 

        public Food()
        {
			// instantiate it 
		}
    }
}
