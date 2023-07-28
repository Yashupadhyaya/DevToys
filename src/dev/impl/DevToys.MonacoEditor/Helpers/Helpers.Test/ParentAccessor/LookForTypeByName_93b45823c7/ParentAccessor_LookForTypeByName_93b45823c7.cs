using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTests
{
    [TestClass]
    public class LookForTypeByNameTests
    {
        private List<Assembly> Assemblies; // TODO: Add assemblies here

        [TestMethod]
        public void TestLookForTypeByName_ReturnsType_WhenTypeIsFoundLocally()
        {
            // Arrange
            var name = "MyType";            
            // Act
            var result = LookForTypeByName(name);            
            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestLookForTypeByName_ReturnsType_WhenTypeIsFoundInOtherAssemblies()
        {
            // Arrange
            var name = "MyType";            
            // Act
            var result = LookForTypeByName(name);            
            // Assert
            Assert.IsNotNull(result);
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
    }
}
