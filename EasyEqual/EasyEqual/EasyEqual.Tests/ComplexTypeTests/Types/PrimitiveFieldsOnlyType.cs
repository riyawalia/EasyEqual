using System;
namespace EasyEqual.Tests.ComplexTypeTests.Types
{
    public class PrimitiveFieldsOnlyType
    {
        public bool BooleanField;
        public int IntegerField; 

        public PrimitiveFieldsOnlyType(bool boolean, int integer)
        {
            BooleanField = boolean;
            IntegerField = integer; 
        }
    }
}
