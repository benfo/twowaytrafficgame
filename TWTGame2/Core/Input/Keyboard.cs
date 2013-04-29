using SdlDotNet.Core;
using SdlDotNet.Input;
using System.Collections.Generic;

namespace TWTGame.Core.Input
{
    public class Keyboard : IKeyboard
    {
        private List<Key> _downKeys;

        public Keyboard()
        {
            _downKeys = new List<Key>();

            Events.KeyboardDown += (sender, args) =>
            {
                if (!_downKeys.Contains(args.Key))
                {
                    _downKeys.Add(args.Key);
                }
            };
            Events.KeyboardUp += (sender, args) =>
            {
                if (_downKeys.Contains(args.Key))
                {
                    _downKeys.Remove(args.Key);
                }
            };
        }

        public bool IsKeyDown(Key key)
        {
            return _downKeys.Contains(key);
        }

        public bool IsKeyUp(Key key)
        {
            return !_downKeys.Contains(key);
        }
    }
}