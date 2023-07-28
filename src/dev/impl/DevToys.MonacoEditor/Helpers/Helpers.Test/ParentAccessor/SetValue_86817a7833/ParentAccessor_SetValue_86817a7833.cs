using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.Reflection;

namespace TestProject
{
    [TestFixture]
    public class TestClass
    {
        private IParentAccessor parentAccessor;
        private Type targetType;

        [SetUp]
        public void Setup()
        {
            parentAccessor = new ParentAccessor();
            targetType = typeof(TargetType);
        }

        [Test]
        public void TestSetValue_Success()
        {
            string name = "PropertyName";
            string value = "{ \"key\": \"value\" }";
            string type = "TargetType";

            parentAccessor.SetValue(name, value, type);

            Assert.IsTrue(parentAccessor.IsSettingValue);
            Assert.AreEqual("value", parentAccessor.PropertyName);
            Assert.IsFalse(parentAccessor.IsSettingValue);
        }

        [Test]
        public void TestSetValue_TypeNotFound()
        {
            string name = "InvalidPropertyName";
            string value = "123";
            string type = "InvalidType";

            Assert.Throws<Exception>(() => parentAccessor.SetValue(name, value, type));
        }

        [Test]
        public void TestSetValue_NullPropertyInfo()
        {
            string name = "InvalidPropertyName";
            string value = "123";
            string type = "TargetType";

            Assert.DoesNotThrow(() => parentAccessor.SetValue(name, value, type));
        }

        [Test]
        public void TestSetValue_NullTargetObject()
        {
            parentAccessor = null;
            string name = "PropertyName";
            string value = "{ \"key\": \"value\" }";
            string type = "TargetType";

            Assert.DoesNotThrow(() => parentAccessor.SetValue(name, value, type));
        }
    }

    public interface IParentAccessor
    {
        public bool IsSettingValue { get; set; }
        public string PropertyName { get; set; }
        public void SetValue(string name, string value, string type);
    }

    public class ParentAccessor : IParentAccessor
    {
        public bool IsSettingValue { get; set; }
        public string PropertyName { get; set; }

        public void SetValue(string name, string value, string type)
        {
            PropertyInfo[] properties = typeof(IParentAccessorAcceptor).GetProperties();
            Type typeInfo = null;

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.Name == "parent")
                {
                    typeInfo = propertyInfo.PropertyType.GetGenericArguments()[1];
                    break;
                }
            }
            
            if (typeInfo is null)
            {
                throw new Exception("Type not found");
            }

            PropertyInfo propInfo = typeInfo.GetProperty(name);
            Type typeObj = null;

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                typeObj = assembly.GetType(type);
                if (typeObj != null)
                {
                    break;
                }
            }

            if (typeObj is null)
            {
                throw new Exception("Type not found");
            }

            object obj = JsonConvert.DeserializeObject(value, typeObj);

            IParentAccessorAcceptor targetObject;
            if (propInfo.TryGetTarget(out targetObject))
            {
                targetObject.IsSettingValue = true;
                propInfo.SetValue(targetObject, obj);
                targetObject.IsSettingValue = false;
            }
        }
    }

    public interface IParentAccessorAcceptor
    {
        public bool IsSettingValue { get; set; }
    }

    public class TargetType : IParentAccessorAcceptor
    {
        public bool IsSettingValue { get; set; }
    }
}
