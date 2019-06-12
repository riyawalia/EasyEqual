using System;
using System.Collections.Generic; 

namespace EasyEqual.Converters
{
    internal struct Comparate
    {
        public HashSet<string> PrimitiveFieldKeys { get; set; }
        public HashSet<Comparate> ComplexComparate { get; set;  }

        public Comparate(HashSet<string> primitiveFieldKeys)
        {
            PrimitiveFieldKeys = primitiveFieldKeys; 
            ComplexComparate = new HashSet<Comparate>();
		}

        public Comparate(HashSet<string> primitiveFieldKeys, HashSet<Comparate> complexComparate)
        {
            PrimitiveFieldKeys = primitiveFieldKeys;
            ComplexComparate = complexComparate; 
        }

        public static bool operator == (Comparate c1, Comparate c2)
		{
            bool primitiveFields =  c1.PrimitiveFieldKeys.SetEquals(c2.PrimitiveFieldKeys);
            bool complexFields = c1.ComplexComparate.SetEquals(c2.ComplexComparate); // double check that this uses == operator defined 

            return complexFields && primitiveFields; 
		}

        public static bool operator != (Comparate c1, Comparate c2)
        {
            return !(c1 == c2); 
        }
    }
}
