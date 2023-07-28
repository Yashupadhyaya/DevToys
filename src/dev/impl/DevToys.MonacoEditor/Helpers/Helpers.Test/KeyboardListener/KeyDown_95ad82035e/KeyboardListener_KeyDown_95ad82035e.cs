using NUnit.Framework;
using System;

namespace YourNamespace.Tests
{
    public class KeyboardListenerTests
    {
        [Test]
        public void TestKeyDown_ReturnsTrue()
        {
            var listener = new KeyboardListener();
            int keycode = 65;
            bool ctrl = true;
            bool shift = false;
            bool alt = true;
            bool meta = false;

            bool result = listener.KeyDown(keycode, ctrl, shift, alt, meta);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestKeyDown_ReturnsFalse_WhenEditorIsNull()
        {
            var listener = new KeyboardListener();
            int keycode = 65;
            bool ctrl = false;
            bool shift = false;
            bool alt = false;
            bool meta = false;

            bool result = listener.KeyDown(keycode, ctrl, shift, alt, meta);

            Assert.IsFalse(result);
        }
    }

    public class KeyboardListener
    {
        private WeakReference<CodeEditorCore> parent;

        public KeyboardListener()
        {
            parent = new WeakReference<CodeEditorCore>(new CodeEditorCore());
        }

        public bool KeyDown(int keycode, bool ctrl, bool shift, bool alt, bool meta)
        {
            if (parent.TryGetTarget(out CodeEditorCore editor))
            {
                return editor.TriggerKeyDown(new WebKeyEventArgs()
                {
                    KeyCode = keycode,
                    CtrlKey = ctrl,
                    ShiftKey = shift,
                    AltKey = alt,
                    MetaKey = meta
                });
            }

            return false;
        }
    }

    public class CodeEditorCore
    {
        public bool TriggerKeyDown(WebKeyEventArgs args)
        {
            return true;
        }
    }

    public class WebKeyEventArgs
    {
        public int KeyCode { get; set; }
        public bool CtrlKey { get; set; }
        public bool ShiftKey { get; set; }
        public bool AltKey { get; set; }
        public bool MetaKey { get; set; }
    }
}
