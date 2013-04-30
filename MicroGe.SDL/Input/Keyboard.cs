using SdlDotNet.Core;
using SdlDotNet.Input;
using System.Collections.Generic;

namespace MicroGe.Input
{
    public class Keyboard : IKeyboard
    {
        private List<Keys> _downKeys;

        public Keyboard()
        {
            _downKeys = new List<Keys>();

            Events.KeyboardDown += (sender, args) =>
            {
                var mappedKey = args.Key.ToTWTKey();
                if (!_downKeys.Contains(mappedKey))
                {
                    _downKeys.Add(mappedKey);
                }
            };
            Events.KeyboardUp += (sender, args) =>
            {
                var mappedKey = args.Key.ToTWTKey();
                if (_downKeys.Contains(mappedKey))
                {
                    _downKeys.Remove(mappedKey);
                }
            };
        }

        public bool IsKeyDown(Keys key)
        {
            return _downKeys.Contains(key);
        }

        public bool IsKeyUp(Keys key)
        {
            return !_downKeys.Contains(key);
        }
    }
}