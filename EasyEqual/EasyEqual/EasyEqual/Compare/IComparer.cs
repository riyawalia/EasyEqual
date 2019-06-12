using System;
namespace EasyEqual.CompareNS
{
    public interface IComparer
    {
        IEqResult AreEqual();
    }
}
