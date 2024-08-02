using InputManager;
using System;
using System.Threading;
using System.Windows.Forms;

namespace LeagueAI.Libraries.Helper
{
    public sealed class InputHelper
    {
        public static void InputWords(string message, int delayPressKey, int delay)
        {
            Thread.Sleep(300);
            foreach (char character in message)
            {
                Thread.Sleep(delayPressKey);
                Keys[] keys = KeyboardMapper.GetKey(character, delayPressKey);

                if (keys == null) continue;

                if (keys.Length == 1)
                {
                    Keyboard.KeyPress(keys[0]);
                    continue;
                }

                if (keys.Length >= 2)
                {
                    Keyboard.KeyDown(keys[0]);
                    Thread.Sleep(delayPressKey);
                    Keyboard.KeyDown(keys[1]);
                    Thread.Sleep(delayPressKey);
                    Keyboard.KeyUp(keys[1]);
                    Thread.Sleep(delayPressKey);
                    Keyboard.KeyUp(keys[0]);
                    continue;
                }
            }
            Thread.Sleep(delay);
        }

        public static void KeyUp(string key, int delay)
        {
            Keyboard.KeyUp((Keys)Enum.Parse(typeof(Keys), key));
            Thread.Sleep(delay);
        }

        public static void KeyDown(string key, int delay)
        {
            Keyboard.KeyDown((Keys)Enum.Parse(typeof(Keys), key));
            Thread.Sleep(delay);
        }

        public static void PressKey(string key, int delay)
            => Keyboard.KeyPress((Keys)Enum.Parse(typeof(Keys), key), delay);

        public static void PressKey(Keys key, int delay) => Keyboard.KeyPress(key, delay);

        public static void PressKey(char key, int delay) => PressKey(key.ToString(), delay);

        public static void RightClick(int x, int y, int delay)
        {
            Mouse.Move(x, y);
            Mouse.PressButton(Mouse.MouseKeys.Right, delay);
        }

        public static void LeftClick(int x, int y, int delay)
        {
            Mouse.Move(x, y);
            Mouse.PressButton(Mouse.MouseKeys.Left, delay);
        }

        public static void MoveMouse(int x, int y) => Mouse.Move(x, y);
    }
}
