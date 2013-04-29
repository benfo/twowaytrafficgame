using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace TWTGame.Core.Graphics
{
    public class DrawManager : IDrawManager, IDisposable
    {
        private Dictionary<string, Texture> _images;

        public DrawManager()
        {
            this.ContentPath = "Content";
            _images = new Dictionary<string, Texture>();
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

        public Texture LoadTexture(string name, string path)
        {
            return this.LoadTextureInternal(name, path);
        }

        public Texture LoadTexture(string name, string path, TextureEffect effect)
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

            var texture = this.LoadTextureInternal(name, path);
            var flippedSurface = effect ==
                 TextureEffect.FlippedHorizontal ?
                 texture.Surface.CreateFlippedHorizontalSurface() :
                 texture.Surface.CreateFlippedVerticalSurface();
            var flippedTexture = new Texture(flippedSurface);

            _images.Add(flippedName, flippedTexture);

            return flippedTexture;
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

        private Texture LoadTextureInternal(string name, string path)
        {
            if (_images.ContainsKey(name))
            {
                return _images[name];
            }

            var texturePath = Path.Combine(this.ContentPath, path);
            var texture = new Texture(new Surface(texturePath));
            _images.Add(name, texture);
            return texture;
        }
    }
}