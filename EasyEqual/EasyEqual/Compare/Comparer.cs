using System;
using EasyEqual.Converters; 

namespace EasyEqual.Compare
{
    public class Comparer<T> : IComparer<T>
    {
        private readonly bool _success = true; 
        private T _actual;
        private T _expected;

        
        public Comparer(T actual, T expected) 
        {
            _actual = actual;
            _expected = expected;
        }

        public IEqResult AreEqual()
        {
            var actualComparate = ConvertToComparate<T>.Convert(_actual);
            var expectedComparate = ConvertToComparate<T>.Convert(_expected);

            var equal = actualComparate == expectedComparate;
            return BuildResponse(equal); 
        }

        public IEqResult BuildSuccessResponse()
        {
            return BuildResponse(_success); 
        }

        public IEqResult BuildFailureResponse()
        {
            return BuildResponse(!_success); 
        }

        public IEqResult BuildResponse(bool equal)
        {
            if (equal)
            {
                return BuildSuccessResponse();
            }
                
            return BuildFailureResponse(); 
        }
    }
}
