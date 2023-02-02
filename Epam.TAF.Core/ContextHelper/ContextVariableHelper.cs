using NUnit.Framework.Internal;
using static NUnit.Framework.TestContext;

namespace Epam.TAF.Core.ContextHelper
{
    public static class ContextVariableHelper
    {
        public static void SetValueToContext(string key, object value)
        {
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(key, value);
        }

        public static T GetValueFromContext<T>(string key)
        {
            return (T)CurrentContext.Test.Properties.Get(key);
        }

        public static bool isValueExist(string key)
        {
            return CurrentContext.Test.Properties.ContainsKey(key);
        }
    }
}
