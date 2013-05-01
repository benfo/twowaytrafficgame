using System;

namespace MicroGe.Graphics
{
    /// <summary>
    /// A base class for all texture implementations.
    /// </summary>
    public abstract class TextureBase : ITexture, IDisposable
    {
        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion IDisposable

        public abstract int Height { get; }

        public string Name { get; set; }

        public abstract int Width { get; }
    }
}