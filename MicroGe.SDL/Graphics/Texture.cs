using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroGe.Graphics
{
    public sealed class Texture : TextureBase
    {
        public Texture(Surface surface)
        {
            this.Surface = surface;
        }

        public Surface Surface { get; private set; }

        protected override void Dispose(bool disposing)
        {
            this.Surface.Dispose();

            base.Dispose(disposing);
        }

        public override int Height
        {
            get { return this.Surface.Height; }
        }

        public override int Width
        {
            get { return this.Surface.Width; }
        }
    }
}
