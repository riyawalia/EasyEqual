﻿using System;
using System.Collections.Generic; 

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

    public class Coffee : Food
    {
        public Foo foo; 
        public Coffee()
        {
            this.foo = new Foo(); 
        }
    }

    public class Fruit : Food
    {
        public List<Foo> listFoo; // instantiate list 
        public Fruit()
        {
            
        }
    }

    public class Food
    {
        public bool perishable; 

        public Food()
        {
            
        }
    }
}
