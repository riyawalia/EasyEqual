using System; 

namespace EasyEqual.CompareNS
{
    public static class Compare
    {
        public static bool AreEqual(object actual, object expected) 
        {
            var comparer = new Comparer(actual, expected);
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

        public static bool AreNotEqual(object actual, object expected)
        {
            var areEqual = AreEqual(actual, expected);
            return !areEqual; 
        }

        public static void AssertEqual(object actual, object expected, string assertionMsg)
        {
            var areEqual = AreEqual(actual, expected);
            throw new NotImplementedException(); 
        }

        public static void AssertUnequal(object actual, object expected, string assertionMsg)
        {
            var areNotEqual = AreNotEqual(actual, expected); 
            throw new NotImplementedException();
        }

    }
}
