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
            if (!primitiveFields)
                return false; 

            foreach(var c1complex in c1.ComplexComparate) {
                bool exists = false;
                foreach(var c2complex in c2.ComplexComparate) {
                    if (c1complex == c2complex) {
                        exists = true;
                        break; 
                    }
                }
                if (!exists)
                    return false; 
            }

            return true; 
		}

        public static bool operator != (Comparate c1, Comparate c2)
        {
            return !(c1 == c2); 
        }

		public override bool Equals(object obj)
		{
            return this == (Comparate) obj; 
		}
    }
}
