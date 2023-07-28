using NUnit.Framework;
using System;
using System.Reflection;

namespace YourNamespace
{
    [TestFixture]
    public class YourTestClass
    {
        [Test]
        public void TestParentAccessor_AddAssemblyForTypeLookup_4918c8b90f()
        {
            YourClass yourObject = new YourClass();
            Assembly assembly = Assembly.GetExecutingAssembly();

            yourObject.AddAssemblyForTypeLookup(assembly);

            Assert.Contains(assembly, yourObject.Assemblies);
        }

        [Test]
        public void TestParentAccessor_AddAssemblyForTypeLookup_4918c8b90f_Failure()
        {
            YourClass yourObject = new YourClass();
            Assembly assembly = null;

            Assert.Throws<ArgumentNullException>(() => yourObject.AddAssemblyForTypeLookup(assembly));
        }
    }
}
