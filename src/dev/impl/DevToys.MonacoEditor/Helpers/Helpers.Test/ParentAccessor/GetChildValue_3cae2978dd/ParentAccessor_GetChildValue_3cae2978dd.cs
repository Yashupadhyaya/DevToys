using NUnit.Framework;
using System;
using System.Reflection;

namespace YourNamespace
{
    [TestFixture]
    public class ParentAccessorTests
    {
        private ParentAccessor parentAccessor;

        [SetUp]
        public void Setup()
        {
            parentAccessor = new ParentAccessor();
        }

        [Test]
        public void TestGetChildValue_Success()
        {
            // Arrange
            string name = "ParentProperty";
            string child = "ChildProperty";
            var parent = new ParentAccessorAcceptor();
            parent.ParentProperty = new ChildAccessor();
            parent.ParentProperty.ChildProperty = "Value";

            // Act
            object result = parentAccessor.GetChildValue(name, child);

            // Assert
            Assert.AreEqual("Value", result);
        }

        [Test]
        public void TestGetChildValue_ParentIsNull()
        {
            // Arrange
            string name = "ParentProperty";
            string child = "ChildProperty";

            // Act
            object result = parentAccessor.GetChildValue(name, child);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void TestGetChildValue_PropertyDoesNotExist()
        {
            // Arrange
            string name = "InvalidProperty";
            string child = "ChildProperty";
            var parent = new ParentAccessorAcceptor();

            // Act
            object result = parentAccessor.GetChildValue(name, child);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void TestGetChildValue_ChildPropertyDoesNotExist()
        {
            // Arrange
            string name = "ParentProperty";
            string child = "InvalidChildProperty";
            var parent = new ParentAccessorAcceptor();
            parent.ParentProperty = new ChildAccessor();

            // Act
            object result = parentAccessor.GetChildValue(name, child);

            // Assert
            Assert.IsNull(result);
        }
    }

    public class ParentAccessor
    {
        public object GetChildValue(string name, string child)
        {
            if (parent.TryGetTarget(out IParentAccessorAcceptor tobj))
            {
                PropertyInfo? propinfo = typeof(IParentAccessorAcceptor).GetProperty(name);
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

    public interface IParentAccessorAcceptor
    {
        object? ParentProperty { get; }
    }

    public class ParentAccessorAcceptor : IParentAccessorAcceptor
    {
        public object? ParentProperty { get; set; }
    }

    public class ChildAccessor
    {
        public object? ChildProperty { get; set; }
    }
}
