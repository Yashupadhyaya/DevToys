using System;
using System.Reflection;
using NUnit.Framework;

namespace YourNamespace
{
    [TestFixture]
    public class YourTestClass
    {
        [Test]
        public void TestParentAccessor_GetChildValue_Success()
        {
            YourClass yourObject = new YourClass();
            yourObject.SetParentAccessor(new IParentAccessorAcceptorMock());

            object? result = yourObject.GetChildValue("ParentProperty", "ChildProperty");

            Assert.AreEqual("ExpectedValue", result);
        }

        [Test]
        public void TestParentAccessor_GetChildValue_ParentNull()
        {
            YourClass yourObject = new YourClass();

            object? result = yourObject.GetChildValue("ParentProperty", "ChildProperty");

            Assert.IsNull(result);
        }
    }

    public interface IParentAccessorAcceptor
    {
        
    }

    public class IParentAccessorAcceptorMock : IParentAccessorAcceptor
    {
        
    }

    public class YourClass
    {
        private IParentAccessorAcceptor? parent;

        public void SetParentAccessor(IParentAccessorAcceptor parentAccessor)
        {
            parent = parentAccessor;
        }

        public object? GetChildValue(string name, string child)
        {
            if (parent.TryGetTarget(out IParentAccessorAcceptor tobj))
            {
                PropertyInfo? propinfo = tobj.GetType().GetProperty(name);
                object? prop = propinfo?.GetValue(tobj);
                if (prop != null)
                {
                    PropertyInfo? childinfo = prop.GetType().GetProperty(child);
                    return childinfo?.GetValue(prop);
                }
            }

            return null;
        }
    }
}
