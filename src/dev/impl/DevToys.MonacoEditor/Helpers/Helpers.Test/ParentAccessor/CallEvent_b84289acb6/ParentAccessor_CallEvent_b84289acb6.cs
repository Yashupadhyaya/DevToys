using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace YourNamespace
{
    [TestClass]
    public class YourClassNameTests
    {
        [TestMethod]
        public async Task TestCallEvent_InvokeExistingEvent_ReturnsResult()
        {
            YourClassName yourClass = new YourClassName();
            string name = "existingEvent";
            string[] parameters = new string[] { "param1", "param2" };

            var result = await yourClass.CallEvent(name, parameters);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestCallEvent_InvokeNonExistingEvent_ReturnsNull()
        {
            YourClassName yourClass = new YourClassName();
            string name = "nonExistingEvent";
            string[] parameters = new string[] { "param1", "param2" };

            var result = await yourClass.CallEvent(name, parameters);

            Assert.IsNull(result);
        }
    }

    public class YourClassName
    {
        private Dictionary<string, Func<string[], string>> events;

        public YourClassName()
        {
            events = new Dictionary<string, Func<string[], string>>();
        }

        public IAsyncOperation<string?>? CallEvent(string name, [ReadOnlyArray] string[] parameters)
        {
            if (events is not null && events.ContainsKey(name))
            {
                return events[name]?.Invoke(parameters).AsAsyncOperation();
            }

            return new Task<string?>(() => { return null; }).AsAsyncOperation();
        }
    }
}
