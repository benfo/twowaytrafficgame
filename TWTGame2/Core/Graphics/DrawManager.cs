using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace TWTGame.Core.Graphics
{
    public class DrawManager : IDrawManager, IDisposable
    {
        private Dictionary<string, Surface> _images;

        public DrawManager()
        {
            this.ContentPath = "Content";
            _images = new Dictionary<string, Surface>();
        }

        public string ContentPath { get; set; }

        public Rectangle ScreenSize
        {
            get
            {
                return new Rectangle(0, 0, Video.Screen.Width, Video.Screen.Height);
            }
        }

        public void Clear(Color color)
        {
            Video.Screen.Fill(color);
        }

        public void Dispose()
        {
            foreach (var image in _images)
            {
                image.Value.Dispose();
            }
        }

        public void Draw(TexturedGameObject gameObject)
        {
            Video.Screen.Blit(gameObject.Sprite, new Point((int)gameObject.Position.X, (int)gameObject.Position.Y));
        }

        public Surface LoadTexture(string name, string path)
        {
            return this.LoadTextureInternal(name, path);
        }

        public Surface LoadTexture(string name, string path, TextureEffect effect)
        {
            if (effect == TextureEffect.None)
            {
                return this.LoadTextureInternal(name, path);
            }

            var flippedName = GetFlippedName(name, effect);

            if (_images.ContainsKey(flippedName))
            {
                return _images[flippedName];
            }

            var surface = this.LoadTextureInternal(name, path);
            var flippedSurface = effect ==
                 TextureEffect.FlippedHorizontal ?
                 surface.CreateFlippedHorizontalSurface() :
                 surface.CreateFlippedVerticalSurface();

            _images.Add(flippedName, flippedSurface);

            return flippedSurface;
        }

        public void Update()
        {
            Video.Screen.Update();
        }

        private string GetFlippedName(string name, TextureEffect effect)
        {
            var flipExtension = effect == TextureEffect.FlippedHorizontal ? "-hflipped" : "-vflipped";
            var flippedName = string.Concat(name, flipExtension);
            return flippedName;
        }

        private Surface LoadTextureInternal(string name, string path)
        {
            if (_images.ContainsKey(name))
            {
                return _images[name];
            }

            var surface = new Surface(Path.Combine(this.ContentPath, path));
            _images.Add(name, surface);
            return surface;
        }
    }
}