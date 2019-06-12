using System;
using EasyEqual.Converters; 

namespace EasyEqual.CompareNS
{
    public class Comparer : IComparer
    {
        private readonly bool _success = true; 
        private object _actual;
        private object _expected;

        
        public Comparer(object actual, object expected) 
        {
            _actual = actual;
            _expected = expected;
        }

        public IEqResult AreEqual()
        {
            var actualComparate = ConvertToComparate.Convert(_actual);
            var expectedComparate = ConvertToComparate.Convert(_expected);

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
            IEqResult result = new EqResult(equal);
            return result; 
        }
    }
}
