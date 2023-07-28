using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestNamespace
{
    public class TestClass
    {
        [Test]
        public void TestRegisterEvent_ThrowsNullReferenceException()
        {
            var testObject = new EventManager();

            Assert.Throws<NullReferenceException>(() => testObject.RegisterEvent("EventName", null));
        }

        [Test]
        public void TestRegisterEvent_AddsEventToDictionary()
        {
            var testObject = new EventManager();
            var eventName = "EventName";
            Func<string[], Task<string?>> function = args => Task.FromResult<string?>("Success");

            testObject.RegisterEvent(eventName, function);

            Assert.IsTrue(testObject.Events.ContainsKey(eventName));
            Assert.AreEqual(function, testObject.Events[eventName]);
        }
    }

    internal class EventManager
    {
        public Dictionary<string, Func<string[], Task<string?>>> Events { get; } = new Dictionary<string, Func<string[], Task<string?>>>();

        internal void RegisterEvent(string name, Func<string[], Task<string?>> function)
        {
            if (Events is null)
            {
                throw new NullReferenceException();
            }

            Events[name] = function;
        }
    }
}
