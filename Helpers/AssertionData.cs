using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
   public static class AssertionData
    {
        public static void AssertionArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertionArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertionStringNotNull(string stringValue, string message)
        {
            if (stringValue == "")
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertionListNotNull(List<string> listObject, string message)
        {
            if (listObject.Count <= 0)
            {
                throw new InvalidOperationException(message);
            }
        }
        public static void AssertionListObjetctNotNull(List<object> listObject, string message)
        {
            if (listObject.Count <= 0)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertionIntNotEqualsZero(int intValue, string message)
        {
            if (intValue == 0)
            {
                throw new InvalidOperationException(message);
            }
        }
        public static void AssertionIntNotNegativeNumber(int intValue, string message)
        {
            if (intValue < 0)
            {
                throw new InvalidOperationException(message);
            }
        }

    }
}
