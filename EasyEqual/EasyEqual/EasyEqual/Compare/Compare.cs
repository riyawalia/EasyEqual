using System; 

namespace EasyEqual.Compare
{
    public static class Compare<T>
    {
        public static bool AreEqual(T actual, T expected) 
        {
            var comparer = new Comparer<T>(actual, expected);
            IEqResult eqResult = null;

            if (actual == null && expected == null)
            {
                eqResult = comparer.BuildSuccessResponse(); 
            }
            else if (actual == null || expected == null)
            {
                eqResult = comparer.BuildFailureResponse(); 
            }
            else 
            {
                eqResult = comparer.AreEqual();
            }

            return eqResult.GetResponse(); 
        }

        public static bool AreNotEqual(T actual, T expected)
        {
            var areEqual = AreEqual(actual, expected);
            return !areEqual; 
        }

        public static void AssertEqual(T actual, T expected, string assertionMsg)
        {
            var areEqual = AreEqual(actual, expected);
            throw new NotImplementedException(); 
        }

        public static void AssertUnequal(T actual, T expected, string assertionMsg)
        {
            var areNotEqual = AreNotEqual(actual, expected); 
            throw new NotImplementedException();
        }

    }
}
