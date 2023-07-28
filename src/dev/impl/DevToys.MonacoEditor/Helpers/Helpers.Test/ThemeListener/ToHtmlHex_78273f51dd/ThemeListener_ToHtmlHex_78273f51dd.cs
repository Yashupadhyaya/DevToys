using NUnit.Framework;
using System;
using Windows.UI;

namespace MyUnitTestProject
{
    public class ColorUtilsTests
    {
        [Test]
        public void TestToHtmlHex_ConvertsColorToHexFormat()
        {
            var color = Color.FromArgb(255, 255, 0, 0);
            var hex = ColorUtils.ToHtmlHex(color);
            Assert.AreEqual("#FF0000", hex);
        }

        [Test]
        public void TestToHtmlHex_ReturnsCorrectHexWithAlpha()
        {
            var color = Color.FromArgb(128, 0, 255, 0);
            var hex = ColorUtils.ToHtmlHex(color);
            Assert.AreEqual("#8000FF00", hex);
        }
    }

    public static class ColorUtils
    {
        public static string ToHtmlHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
        }
    }
}
