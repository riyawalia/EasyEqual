using System;
using System.Collections.Generic; 

namespace EasyEqual.Converters
{
    internal struct Comparate
    {
        public HashSet<string> PrimitiveFieldKeys { get; set; }
        // public HashSet<Comparate> ComplexComparate { get; set;  }

        public Comparate(HashSet<string> primitiveFieldKeys)
        {
            PrimitiveFieldKeys = primitiveFieldKeys; 
        }

        public static bool operator == (Comparate c1, Comparate c2)
		{
            return c1.PrimitiveFieldKeys.SetEquals(c2.PrimitiveFieldKeys); 
		}

        public static bool operator != (Comparate c1, Comparate c2)
        {
            return !(c1 == c2); 
        }
    }
}
