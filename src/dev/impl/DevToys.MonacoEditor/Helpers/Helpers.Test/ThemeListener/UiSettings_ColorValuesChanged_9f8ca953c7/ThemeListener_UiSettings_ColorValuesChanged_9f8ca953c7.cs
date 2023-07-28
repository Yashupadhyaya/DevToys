using NUnit.Framework;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace YourNamespace
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public async void TestThemeListener_UiSettings_ColorValuesChanged_9f8ca953c7()
        {
            // Arrange
            bool updatePropertiesCalled = false;
            
            var uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UiSettings_ColorValuesChangedEventHandler;

            // Act
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, 
                () => uiSettings.OnColorValuesChanged(uiSettings, EventArgs.Empty));

            // Assert
            Assert.IsTrue(updatePropertiesCalled);

            // Clean up
            uiSettings.ColorValuesChanged -= UiSettings_ColorValuesChangedEventHandler;
        }

        private void UiSettings_ColorValuesChangedEventHandler(UISettings sender, object args)
        {
            updatePropertiesCalled = true;
            // Add necessary check here if needed
        }
    }
}
