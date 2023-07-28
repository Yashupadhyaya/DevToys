// Test generated by RoostGPT for test int-test using AI Type Azure Open AI and AI Model roost-gpt

using NUnit.Framework;
using System;
using Windows.UI;

namespace YourNamespace
{
    [TestFixture]
    public class YourTestClass
    {
        [Test]
        public void TestToHtmlHex_WithBlackColor_ReturnsHexCode00000000()
        {
            // Arrange
            Color color = Color.FromArgb(255, 0, 0, 0);
            
            // Act
            string hexCode = ToHtmlHex(color);
            
            // Assert
            Assert.AreEqual("#00000000", hexCode);
        }

        [Test]
        public void TestToHtmlHex_WithWhiteColor_ReturnsHexCodeFFFFFFFF()
        {
            // Arrange
            Color color = Color.FromArgb(255, 255, 255, 255);
            
            // Act
            string hexCode = ToHtmlHex(color);
            
            // Assert
            Assert.AreEqual("#FFFFFFFF", hexCode);
        }

        public static string ToHtmlHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
        }
    }
}
