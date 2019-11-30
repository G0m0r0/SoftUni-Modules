using MyTestingframework.Attributes;
using MyTestingframework.Execption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyTestingframework.Executor
{
    public class Executor
    {
        public void Execute(Assembly assembly)
        {
            StringBuilder sb = new StringBuilder();
            var testClasses = assembly
                .GetTypes()
                .Where(a => a.GetCustomAttributes(typeof(MyTestFixtureAttribute))
                .Any());

            foreach (var type in testClasses)
            {

                var testMethods = type.GetMethods()
                    .Where(a => a.GetCustomAttributes(typeof(MyTestAttribute)).Any());

                var instance = Activator.CreateInstance(type);

                foreach (var testMethod in testMethods)
                {
                    try
                    {
                        testMethod.Invoke(instance, new object[] { });
                        sb.AppendLine($"{testMethod.Name} passed!");
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException.GetType() == typeof(MyTestException))
                            sb.AppendLine($"{testMethod.Name} not passed!");
                    }
                }
            }

            File.AppendAllText("../../../testingResult.txt", sb.ToString().TrimEnd());
        }
    }
}
