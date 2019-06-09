using System;
using EasyEqual.Compare; 
namespace EasyEqual.Tests
{
    internal interface IEasyEqualTest<T>
    {
        void AreEqual_SameObjectTest();
        void AreEqual_DifferentObjectTest();
		void AreEqual_ValuesAreNullTest();
        void AreEqual_ValuesAreDefaultTest(); 

        void AreUnequalTest();
        void AreUnequal_ActualValueIsNullTest(); 
        void AreUnequal_ExpectedValueIsNullTest();
        void AreUnequal_ActualValueIsDefaultTest();
        void AreUnequal_ExpectedValueIsDefaultTest();

	}
}
