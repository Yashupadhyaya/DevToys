using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace YourNamespace
{
    [TestFixture]
    public class YourTestClass
    {
        [Test]
        public void TestRegisterAction_ThrowsNullReferenceException()
        {
            var obj = new YourClass();

            Assert.Throws<NullReferenceException>(() => obj.RegisterAction("action1", null));
        }

        [Test]
        public void TestRegisterAction_AddsActionToDictionary()
        {
            var obj = new YourClass();
            var action = new Action(() => Console.WriteLine("This is an action"));

            obj.RegisterAction("action1", action);

            Assert.IsNotNull(obj.Actions["action1"]);
            Assert.AreEqual(action, obj.Actions["action1"]);
        }
    }

    public class YourClass
    {
        public Dictionary<string, Action> Actions { get; set; }

        public YourClass()
        {
            Actions = new Dictionary<string, Action>();
        }

        internal void RegisterAction(string name, Action action)
        {
            if (Actions is null)
            {
                throw new NullReferenceException();
            }

            Actions[name] = action;
        }
    }
}
