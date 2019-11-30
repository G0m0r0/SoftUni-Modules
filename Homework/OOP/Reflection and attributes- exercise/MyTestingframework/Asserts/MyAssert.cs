using MyTestingframework.Execption;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyTestingframework.Asserts
{
    public abstract class MyAssert
    {
        public static void AreEqual(object expected,object actual)
        {
            var result = Comparer.DefaultInvariant.Compare(expected, actual);

            if(result!=0)
            {
                throw new MyTestException();
            }
        }
    }
}
