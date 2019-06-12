using System;
namespace EasyEqual.Tests.ComplexTypeTests.Types
{
    public class NestedObjectType
    {
        public PrimitiveFieldsOnlyType NestedObjField;
        public int IntegerField; 
        public NestedObjectType(PrimitiveFieldsOnlyType nestedObjField, int integerField)
        {
            IntegerField = integerField;
            NestedObjField = nestedObjField; 
        }
    }
}
