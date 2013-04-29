using SdlDotNet.Graphics;
using System;

namespace TWTGame.Core.Graphics
{
    public class Texture : IDisposable
    {
        public Texture(Surface surface)
        {
            if (surface == null)
            {
                throw new ArgumentNullException("surface");
            }

            this.Surface = surface;
        }

        public Surface Surface { get; private set; }

        public void Dispose()
        {
            this.Surface.Dispose();
            this.Surface = null;
        }

        public int Width
        {
            get
            {
                return this.Surface.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.Surface.Height;
            }
        }
    }
}