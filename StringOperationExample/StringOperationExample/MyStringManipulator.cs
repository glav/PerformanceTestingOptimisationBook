using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringOperationExample
{
    class MyStringManipulator
    {
        const string SomeStringData = "QWERTYUIOPASDFGHJKLZXCVBNM";

        public int UseRegularString(int numberOfOperations)
        {
            string myStringData = null;

            for (int cnt = 0; cnt < numberOfOperations;cnt++ )
            {
                myStringData += SomeStringData;
            }

            return myStringData.Length;
        }

        public int UseStringBuilder(int numberOfOperations)
        {
            StringBuilder myStringData = new StringBuilder();

            for (int cnt = 0; cnt < numberOfOperations; cnt++)
            {
                myStringData.Append(SomeStringData);
            }

            return myStringData.Length;
        }
    }
}
