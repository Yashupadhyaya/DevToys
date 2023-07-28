using NUnit.Framework;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace ThemeListener.Tests
{
    [TestFixture]
    public class ThemeListenerTests
    {
        [Test]
        public void TestThemeListener_ThemeListener_16296c939f()
        {
            // Arrange
            ThemeListener listener;

            // Act
            listener = new ThemeListener();

            // Assert
            Assert.IsNotNull(listener);
        }

        [Test]
        public void TestThemeListener_ThemeListener_CurrentThemeSetToDark()
        {
            // Arrange
            ThemeListener listener;
            ElementTheme expectedTheme = ElementTheme.Dark;
            
            // Act
            listener = new ThemeListener();
            FrameworkElement frameworkElement = new FrameworkElement();
            frameworkElement.ActualTheme = expectedTheme;
            Window.Current.Content = frameworkElement;

            // Assert
            Assert.AreEqual(expectedTheme, listener.CurrentTheme);
        }
    }
}
