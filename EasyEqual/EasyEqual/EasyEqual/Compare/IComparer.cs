using System;
namespace EasyEqual.Compare
{
    public interface IComparer<T>
    {
        IEqResult AreEqual();
    }
}
