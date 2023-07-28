using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace YourNamespace
{
    public class YourClassTests
    {
        [Test]
        public void Test_AddAssemblyForTypeLookup_AddsAssemblyToList()
        {
            YourClass yourClass = new YourClass();
            Assembly assembly = Assembly.GetExecutingAssembly();

            yourClass.AddAssemblyForTypeLookup(assembly);

            CollectionAssert.Contains(yourClass.Assemblies, assembly);
        }
        
        [Test]
        public void Test_AddAssemblyForTypeLookup_DoesNotAddDuplicateAssemblyToList()
        {
            YourClass yourClass = new YourClass();
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            yourClass.AddAssemblyForTypeLookup(assembly);
            yourClass.AddAssemblyForTypeLookup(assembly);

            yourClass.AddAssemblyForTypeLookup(assembly);

            Assert.AreEqual(1, yourClass.Assemblies.Count);
            CollectionAssert.Contains(yourClass.Assemblies, assembly);
        }
    }

    internal class YourClass
    {
        public List<Assembly> Assemblies { get; } = new List<Assembly>();

        internal void AddAssemblyForTypeLookup(Assembly assembly)
        {
            Assemblies.Add(assembly);
        }
    }
}
