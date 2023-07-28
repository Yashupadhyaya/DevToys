// Test generated by RoostGPT for test unt-test using AI Type Azure Open AI and AI Model roost-gpt

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
            // TODO: Initialize the parentAccessor object with appropriate values or mock objects
            parentAccessor = new ParentAccessor();
        }

        [Test]
        public void TestGetValue_WhenParentIsNull_ReturnsNull()
        {
            // Arrange
            parentAccessor.SetParent(null);
            string propertyName = "Name";

            // Act
            var result = parentAccessor.GetValue(propertyName);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void TestGetValue_WhenPropertyExists_ReturnsPropertyValue()
        {
            // Arrange
            var parent = new ParentAccessorAcceptor();
            parent.Name = "John";
            parentAccessor.SetParent(parent);
            string propertyName = "Name";

            // Act
            var result = parentAccessor.GetValue(propertyName);

            // Assert
            Assert.AreEqual("John", result);
        }

        [Test]
        public void TestGetValue_WhenPropertyDoesNotExist_ReturnsNull()
        {
            // Arrange
            var parent = new ParentAccessorAcceptor();
            parentAccessor.SetParent(parent);
            string propertyName = "Age";

            // Act
            var result = parentAccessor.GetValue(propertyName);

            // Assert
            Assert.IsNull(result);
        }
    }

    public class ParentAccessor
    {
        private WeakReference<IParentAccessorAcceptor> parent;

        public void SetParent(IParentAccessorAcceptor parent)
        {
            this.parent = new WeakReference<IParentAccessorAcceptor>(parent);
        }

        public object? GetValue(string name)
        {
            if (parent.TryGetTarget(out IParentAccessorAcceptor targetObject))
            {
                PropertyInfo? propertyInfo = targetObject.GetType().GetProperty(name);
                return propertyInfo?.GetValue(targetObject);
            }

            return null;
        }
    }

    public interface IParentAccessorAcceptor
    {
        // Add relevant properties or methods here for testing
        public string Name { get; set; }
    }

    public class ParentAccessorAcceptor : IParentAccessorAcceptor
    {
        public string Name { get; set; }
    }
}
