using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestNamespace
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestLookForTypeByName_LocalSearch()
        {
            // Arrange
            TestClass testClass = new TestClass();
            string typeName = "TestClass";

            // Act
            Type? result = testClass.LookForTypeByName(typeName);

            // Assert
            Assert.AreEqual(typeof(TestClass), result);
        }

        [Test]
        public void TestLookForTypeByName_OtherAssembliesSearch()
        {
            // Arrange
            TestClass testClass = new TestClass();
            string typeName = "TestClass2";

            // Act
            Type? result = testClass.LookForTypeByName(typeName);

            // Assert
            Assert.IsNull(result);
        }

        private Type? LookForTypeByName(string name)
        {
            // First search locally
            var result = Type.GetType(name);

            if (result != null)
            {
                return result;
            }

            // Search in Other Assemblies
            foreach (Assembly? assembly in Assemblies)
            {
                foreach (Type? typeInfo in assembly.ExportedTypes)
                {
                    if (typeInfo.Name == name)
                    {
                        return typeInfo;
                    }
                }
            }

            return null;
        }

        private IEnumerable<Assembly> Assemblies
        {
            // TODO: Add logic to get assemblies
            get { return null; }
        }
    }
}
