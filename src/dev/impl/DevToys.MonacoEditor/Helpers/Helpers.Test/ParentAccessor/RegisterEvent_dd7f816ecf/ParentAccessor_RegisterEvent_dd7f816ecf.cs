using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyNamespace
{
    [TestFixture]
    public class MyClassTests
    {
        [Test]
        public void TestRegisterEvent_WhenEventsIsNull_ThrowsNullReferenceException()
        {
            // Arrange
            MyClass myClass = new MyClass();
            string name = "EventName";
            Func<string[], Task<string?>> function = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => myClass.RegisterEvent(name, function));
        }

        [Test]
        public void TestRegisterEvent_WhenEventsIsNotNull_RegistersEventSuccessfully()
        {
            // Arrange
            MyClass myClass = new MyClass();
            string name = "EventName";
            Func<string[], Task<string?>> function = args => Task.FromResult("Result");

            // Act
            myClass.RegisterEvent(name, function);

            // Assert
            Assert.IsTrue(myClass.Events.ContainsKey(name));
            Assert.AreEqual(myClass.Events[name], function);
        }
    }

    internal class MyClass
    {
        public Dictionary<string, Func<string[], Task<string?>>> Events { get; private set; }

        public MyClass()
        {
            Events = new Dictionary<string, Func<string[], Task<string?>>>();
        }

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
