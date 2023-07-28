using NUnit.Framework;
using System;
using System.Reflection;

namespace YourNamespace
{
    public class ParentAccessorTests
    {
        private ParentAccessor parentAccessor;
        
        [SetUp]
        public void Setup()
        {
            parentAccessor = new ParentAccessor();
        }
        
        [Test]
        public void TestSetValue_WhenParentIsNull_ShouldNotSetValue()
        {
            object value = 10;
            parentAccessor.SetValue("SomeProperty", value);
        }
        
        [Test]
        public void TestSetValue_WhenParentIsNotNullAndPropertyExists_ShouldSetValue()
        {
            var parent = new SampleParent();
            parentAccessor.SetParent(parent);
            object value = "Test Value";
            parentAccessor.SetValue("SomeProperty", value);
        }
        
        private class ParentAccessor
        {
            private WeakReference<IParentAccessorAcceptor> parent;
            private TypeInfo typeinfo;
            
            public void SetValue(string name, object value)
            {
                if (parent.TryGetTarget(out IParentAccessorAcceptor tobj))
                {
                    PropertyInfo? propinfo = typeinfo.GetProperty(name);
                    tobj.IsSettingValue = true;
                    propinfo?.SetValue(tobj, value);
                    tobj.IsSettingValue = false;
                }
            }
        }
        
        private interface IParentAccessorAcceptor
        {
            bool IsSettingValue { get; set; }
        }
        
        private class SampleParent : IParentAccessorAcceptor
        {
            public bool IsSettingValue { get; set; }
            
            public object SomeProperty { get; set; }
        }
    }
}
