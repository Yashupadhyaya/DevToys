using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyNamespace.Tests
{
    [TestFixture]
    public class MyTestClass
    {
        [Test]
        public void TestDispose_WhenActionsIsNotNull_ShouldClearActions()
        {
            // Arrange
            var myObject = new MyObject();
            myObject.actions = new List<Action>();

            // Act
            myObject.Dispose();

            // Assert
            Assert.IsNull(myObject.actions);
        }

        [Test]
        public void TestDispose_WhenActionsIsNull_ShouldNotThrowException()
        {
            // Arrange
            var myObject = new MyObject();
            myObject.actions = null;

            // Act and Assert
            Assert.DoesNotThrow(() => myObject.Dispose());
        }

        [Test]
        public void TestDispose_WhenEventsIsNotNull_ShouldClearEvents()
        {
            // Arrange
            var myObject = new MyObject();
            myObject.events = new List<Event>();

            // Act
            myObject.Dispose();

            // Assert
            Assert.IsNull(myObject.events);
        }

        [Test]
        public void TestDispose_WhenEventsIsNull_ShouldNotThrowException()
        {
            // Arrange
            var myObject = new MyObject();
            myObject.events = null;

            // Act and Assert
            Assert.DoesNotThrow(() => myObject.Dispose());
        }
    }

    public class MyObject : IDisposable
    {
        public List<Action> actions;
        public List<Event> events;

        public void Dispose()
        {
            if (actions != null)
            {
                actions.Clear();
            }

            actions = null;

            if (events != null)
            {
                events.Clear();
            }

            events = null;
        }
    }

    public class Event
    {
        // Event properties and methods...
    }
}
