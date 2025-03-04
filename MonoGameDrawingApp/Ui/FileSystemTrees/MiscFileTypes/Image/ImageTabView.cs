﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameDrawingApp.Ui.Base;
using System;

namespace MonoGameDrawingApp.Ui.FileSystemTrees.MiscFileTypes.Image
{
    public class ImageTabView : IUiElement
    {
        private const int Spacing = 20;
        private readonly IUiElement _root;

        private readonly IUiElement _image;

        private readonly MinSize _minSize;

        public ImageTabView(UiEnvironment environment, string path)
        {
            Environment = environment;
            Path = path;
            _image = new ExternalImageView(
                environment: environment,
                path: path
            );

            _minSize = new MinSize(
                environment: environment,
                child: new ScaleView(
                    environment: environment,
                    child: _image,
                    disableBlur: true
                ),
                width: 1,
                height: 1
            );

            _root = new CenterView(environment, _minSize, true, true);
        }

        public bool Changed => _root.Changed;

        public int RequiredWidth => _root.RequiredWidth;

        public int RequiredHeight => _root.RequiredHeight;

        public UiEnvironment Environment { get; }
        public string Path { get; set; }

        public Texture2D Render(Graphics graphics, int width, int height)
        {
            return _root.Render(graphics, width, height);
        }

        public void Update(Vector2 position, int width, int height)
        {
            _root.Update(position, width, height);
            int size = Math.Min(width, height) - Spacing;
            float ratio = _image.RequiredHeight / (float)_image.RequiredWidth;
            _minSize.MinWidth = ratio > 1 ? (int)(size / ratio) : size;
            _minSize.MinHeight = ratio < 1 ? (int)(size * ratio) : size;
        }
    }
}
