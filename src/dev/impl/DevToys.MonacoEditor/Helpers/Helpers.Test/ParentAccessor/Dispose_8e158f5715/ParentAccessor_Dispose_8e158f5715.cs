using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class DisposeTests
    {
        [TestMethod]
        public void TestDispose_WithActionsAndEvents_CorrectlyClearsLists()
        {
            // Arrange
            DisposeTestClass disposeTest = new DisposeTestClass();
            disposeTest.actions = new List<string> { "Action1", "Action2", "Action3" };
            disposeTest.events = new List<string> { "Event1", "Event2", "Event3" };

            // Act
            disposeTest.Dispose();

            // Assert
            Assert.IsNull(disposeTest.actions);
            Assert.IsNull(disposeTest.events);
        }

        [TestMethod]
        public void TestDispose_WithoutActionsAndEvents_DoesNothing()
        {
            // Arrange
            DisposeTestClass disposeTest = new DisposeTestClass();

            // Act
            disposeTest.Dispose();

            // Assert
            Assert.IsNull(disposeTest.actions);
            Assert.IsNull(disposeTest.events);
        }
    }

    public class DisposeTestClass
    {
        public List<string> actions;
        public List<string> events;

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
}
