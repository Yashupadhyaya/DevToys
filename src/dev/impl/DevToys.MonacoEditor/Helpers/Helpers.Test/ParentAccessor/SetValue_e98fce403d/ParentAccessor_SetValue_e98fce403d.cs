using NUnit.Framework;
using System;
using System.Reflection;

[TestFixture]
public class ParentAccessorTests
{
    private Type typeinfo = typeof(IParentAccessorAcceptor);

    [Test]
    public void TestSetValue_Success()
    {
        // Arrange
        ParentAccessor parent = new ParentAccessor();
        ChildAccessor child = new ChildAccessor();
        parent.TargetObject = child;
        
        // Act
        parent.SetValue("Name", "John");
        
        // Assert
        Assert.AreEqual("John", child.Name);
    }

    [Test]
    public void TestSetValue_Failure()
    {
        // Arrange
        ParentAccessor parent = new ParentAccessor();
        ChildAccessor child = new ChildAccessor();
        parent.TargetObject = child;
        
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => parent.SetValue(null, "John"));
        Assert.Throws<ArgumentNullException>(() => parent.SetValue("Name", null));
        Assert.Throws<ArgumentException>(() => parent.SetValue("Age", 25));
    }
}

public interface IParentAccessorAcceptor
{
    bool IsSettingValue { get; set; }
}

public class ChildAccessor : IParentAccessorAcceptor
{
    public string Name { get; set; }
    public bool IsSettingValue { get; set; }
}

public class ParentAccessor
{
    private WeakReference<IParentAccessorAcceptor> parent = new WeakReference<IParentAccessorAcceptor>(null);

    public IParentAccessorAcceptor TargetObject
    {
        set
        {
            parent = new WeakReference<IParentAccessorAcceptor>(value);
        }
    }

    public void SetValue(string name, object value)
    {
        if (parent.TryGetTarget(out IParentAccessorAcceptor tobj))
        {
            PropertyInfo? propinfo = typeinfo.GetProperty(name); // TODO: Cache these?
            tobj.IsSettingValue = true;
            propinfo?.SetValue(tobj, value);
            tobj.IsSettingValue = false;
        }
    }
}
