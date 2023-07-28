using NUnit.Framework;
using System;
using System.Reflection;

namespace YourNamespace
{
    [TestFixture]
    public class ParentAccessorTests
    {
        private ParentAccessor parent;
        private IParentAccessorAcceptor mockObject;
        private ParentAccessorAccessor accessor;

        [SetUp]
        public void Setup()
        {
            mockObject = new MockObject();
            parent = new ParentAccessor(mockObject);
            accessor = new ParentAccessorAccessor(parent);
        }

        [TearDown]
        public void Teardown()
        {
            parent = null;
            mockObject = null;
            accessor = null;
        }

        [TestCase("FirstName")]
        public void TestParentAccessor_GetValue_Success(string propertyName)
        {
            // Arrange

            // Act
            object value = accessor.GetValue(propertyName);

            // Assert
            Assert.IsNotNull(value);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("InvalidProperty")]
        public void TestParentAccessor_GetValue_Null(string propertyName)
        {
            // Arrange

            // Act
            object value = accessor.GetValue(propertyName);

            // Assert
            Assert.IsNull(value);
        }

        // TODO: Add more test cases for edge cases and error handling
    }

    // Mock object for testing
    public class MockObject : IParentAccessorAcceptor
    {
        public string FirstName { get; set; }
    }

    // Accessor class to access parent object's internal method
    public class ParentAccessorAccessor
    {
        private ParentAccessor parentAccessor;

        public ParentAccessorAccessor(ParentAccessor parentAccessor)
        {
            this.parentAccessor = parentAccessor;
        }

        public object GetValue(string name)
        {
            return parentAccessor.GetValue(name);
        }
    }
}
