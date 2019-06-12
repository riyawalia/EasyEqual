using System;
using System.Collections.Generic; 

namespace EasyEqual.Converters
{
    internal struct Comparate
    {
        public HashSet<string> PrimitiveFieldKeys { get; set; }
        public List<Comparate> ComplexComparate { get; set;  }

        public Comparate(HashSet<string> primitiveFieldKeys)
        {
            PrimitiveFieldKeys = primitiveFieldKeys; 
            ComplexComparate = new List<Comparate>();
		}

        public Comparate(HashSet<string> primitiveFieldKeys, List<Comparate> complexComparate)
        {
            PrimitiveFieldKeys = primitiveFieldKeys;
            ComplexComparate = complexComparate; 
        }

        public static bool operator == (Comparate c1, Comparate c2)
		{
            if (c1.ComplexComparate.Count != c2.ComplexComparate.Count)
                return false;
            if (!c1.PrimitiveFieldKeys.SetEquals(c2.PrimitiveFieldKeys))
                return false; 

            var found = new List<bool>(c1.ComplexComparate.Count);

			foreach(var c1complex in c1.ComplexComparate) {
                bool exists = false;
                int curr = 0; 
                foreach(var c2complex in c2.ComplexComparate) {
                    if (c1complex == c2complex && !found[curr]) {
                        exists = true;
                        found[curr] = true; 
                        break; 
                    }
                    ++curr; 
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
