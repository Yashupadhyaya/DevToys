using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Media;
using NUnit.Framework;

namespace YourNamespace
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public async void TestUiSettings_ColorValuesChanged()
        {
            var uiSettings = new UISettings(); 

            var expectedValue = ""; 

            await uiSettings.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                UiSettings_ColorValuesChanged(uiSettings, null);

                Assert.AreEqual(expectedValue, uiSettings.Property); 
            });
        }
    }
}
