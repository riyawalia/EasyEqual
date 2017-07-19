using System;
namespace EasyEqual
{
    public partial class Compare<T>
    {
        #region EqualityChecks
        public static bool AreEqual(T actual, T expected)
        {
            var compare = new Compare<T>(actual, expected);

            return compare.AreEqual();
        }

        public static bool AreEqual(T actual, T expected, bool deepEquality)
        {
            var compare = new Compare<T>(actual, expected);

            return compare.AreEqual(deepEquality);
        }
        #endregion

        #region EqualityAssertions
        public void ShouldEqual()
        {
            this.ShouldEqual(deepEquality: false);
        }

        public void ShouldNotEqual()
        {
            this.ShouldEqual(deepEquality: false);
        }
        #endregion

        #region Details

        #endregion

        #region StaticMethods
        public static void ShouldEqual(T actual, T expected)
        {
            var compare = new Compare<T>(actual, expected);

            compare.ShouldEqual();
        }

        public static void ShouldNotEqual(T actual, T expected)
        {
            var compare = new Compare<T>(actual, expected);

            compare.ShouldNotEqual();
        }

        public static void ShouldEqual(T actual, T expected, bool deepEquality)
        {
            var compare = new Compare<T>(actual, expected);

            compare.ShouldEqual(deepEquality: deepEquality);
        }

        public static void ShouldNotEqual(T actual, T expected, bool deepEquality)
        {
            var compare = new Compare<T>(actual, expected);

            compare.ShouldNotEqual(deepEquality: deepEquality);
        }
        #endregion
    }
}
