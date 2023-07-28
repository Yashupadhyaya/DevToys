using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestNamespace
{
    public class TestClass
    {
        [Test]
        public void TestParentAccessor_RegisterAction_617d58ef22_Success()
        {
            string name = "testAction";
            Action action = () => Console.WriteLine("Executing testAction");

            ParentClass parent = new ParentClass();
            parent.RegisterAction(name, action);
            
            Assert.IsTrue(parent.Actions.ContainsKey(name));
            Assert.AreEqual(action, parent.Actions[name]);
        }

        [Test]
        public void TestParentAccessor_RegisterAction_617d58ef22_NullReferenceException()
        {
            string name = "testAction";
            Action action = null;

            ParentClass parent = new ParentClass();

            Assert.Throws<NullReferenceException>(() => parent.RegisterAction(name, action));
        }
    }

    internal class ParentClass
    {
        public Dictionary<string, Action> Actions { get; set; }

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
