using NUnit.Framework;
using DevToys.MonacoEditor.CodeEditorControl;
using Windows.Foundation.Metadata;

namespace NUnitTests
{
    [TestFixture]
    public class KeyboardListenerTests
    {
        [TestCase]
        public void TestKeyDown_Success()
        {
            var listener = new KeyboardListener();
            int keycode = 123;
            bool ctrl = true;
            bool shift = false;
            bool alt = true;
            bool meta = false;

            bool result = listener.KeyDown(keycode, ctrl, shift, alt, meta);

            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestKeyDown_Failure()
        {
            var listener = new KeyboardListener();
            int keycode = 456;
            bool ctrl = false;
            bool shift = true;
            bool alt = false;
            bool meta = true;

            bool result = listener.KeyDown(keycode, ctrl, shift, alt, meta);

            Assert.IsFalse(result);
        }
    }
}
