using System;
using System.Collections.Generic; 

namespace EasyEqual
{
    public class Foo
    {
        public int a;
        public string b; 
        public Foo()
        {
            
        }
        public Foo(int a , string b)
        {
            this.a = a;
            this.b = b; 
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
