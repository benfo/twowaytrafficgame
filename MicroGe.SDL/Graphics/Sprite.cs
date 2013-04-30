using MicroGe.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroGe.Graphics
{
    public class Sprite : SpriteBase
    {
        protected internal SdlDotNet.Graphics.Sprites.Sprite _sprite;

        public Sprite(ITexture texture)
            : base(texture)
        {
            _sprite = new SdlDotNet.Graphics.Sprites.Sprite(((Texture)texture).Surface);
        }

        public override int X
        {
            get { return _sprite.X; }
            set { _sprite.X = value; }
        }

        public override int Y
        {
            get { return _sprite.Y; }
            set { _sprite.Y = value; }
        }

        public override int Width
        {
            get { return _sprite.Width; }
        }

        public override int Height
        {
            get { return _sprite.Height; }
        }
    }
}
