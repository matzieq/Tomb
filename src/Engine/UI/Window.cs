using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tomb.Engine.UI
{
    public class RectangleSprite
    {
        static Texture2D _pointTexture;



        public static void DrawSolid(Rectangle rectangle, Color color)
        {
            if (_pointTexture == null)
            {
                _pointTexture = new Texture2D(Globals.spriteBatch.GraphicsDevice, 1, 1);
                _pointTexture.SetData<Color>(new Color[] { Color.White });
            }
            Globals.spriteBatch.Draw(_pointTexture, rectangle, color);

        }
        public static void DrawOutlne(Rectangle rectangle, Color color, int lineWidth)
        {
            if (_pointTexture == null)
            {
                _pointTexture = new Texture2D(Globals.spriteBatch.GraphicsDevice, 1, 1);
                _pointTexture.SetData<Color>(new Color[] { Color.White });
            }


            Globals.spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            Globals.spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            Globals.spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            Globals.spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }
    }

    public class Bar
    {
        public Vector2 Position;
        int _maxValue;
        public int CurrentValue;
        int _maxWidth;
        int _height;


        public Color TintColor;

        public Bar(Vector2 position, int maxValue, Color color, int maxWidth, int height)
        {
            Position = position;
            _maxValue = maxValue;
            CurrentValue = maxValue;
            TintColor = color;
            _maxWidth = maxWidth;
            _height = height;
        }

        public void Draw(GameTime gameTime, bool outlined = false)
        {
            int width = (int)Math.Round((CurrentValue / (float)_maxValue) * _maxWidth);
            if (outlined)
            {
                var outlineThickness = 1;
                var outlineColorModifier = 150;
                RectangleSprite.DrawSolid(
                    new Rectangle((int)Position.X - outlineThickness,
                                (int)Position.Y - outlineThickness,
                                _maxWidth + outlineThickness * 2,
                                _height + outlineThickness * 2),
                    new Color(TintColor.R - outlineColorModifier,
                            TintColor.G - outlineColorModifier,
                            TintColor.B - outlineColorModifier)
                );
            }
            RectangleSprite.DrawSolid(new Rectangle((int)Position.X, (int)Position.Y, width, _height), TintColor);
        }
    }

    public class Window
    {
        public Vector2 Position
        {
            get
            {
                return new Vector2(WindowRectangle.X, WindowRectangle.Y);
            }
        }
        public Rectangle WindowRectangle;
        Rectangle _currentRectangle;
        int _outlineWidth;
        bool isOpening = true;
        bool isClosing = false;
        public bool IsClosed = false;
        bool isOpen = false;
        float currentHeight = 0;
        float currentY = 0;
        readonly float _openingSpeed = 150;
        public bool IsActive = false;

        public Window(Rectangle windowRectangle, int outlineWidth)
        {
            WindowRectangle = windowRectangle;
            currentY = windowRectangle.Y + windowRectangle.Height / 2;
            currentHeight = 0f;
            _currentRectangle = new Rectangle(windowRectangle.X, (int)currentY, windowRectangle.Width, (int)currentHeight);

            _outlineWidth = outlineWidth;
            isOpening = true;
        }

        public virtual void Draw(GameTime gameTime)
        {
            RectangleSprite.DrawSolid(_currentRectangle, Color.Black);
            RectangleSprite.DrawOutlne(_currentRectangle, IsActive ? Color.White : Color.Gray, _outlineWidth);
            if (isOpen)
            {
                DrawContents(gameTime);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (isOpening)
            {
                if (currentY > WindowRectangle.Y)
                {
                    currentY -= (float)gameTime.ElapsedGameTime.TotalSeconds * _openingSpeed;
                    _currentRectangle.Y = (int)currentY;
                }
                else
                {
                    currentY = WindowRectangle.Y;
                }

                if (currentHeight < WindowRectangle.Height)
                {
                    currentHeight += (float)gameTime.ElapsedGameTime.TotalSeconds * 2 * _openingSpeed;
                    _currentRectangle.Height = (int)currentHeight;
                }
                else
                {
                    currentHeight = WindowRectangle.Height;
                }

                if (_currentRectangle.Y <= WindowRectangle.Y && _currentRectangle.Height >= WindowRectangle.Height)
                {
                    isOpening = false;
                    isOpen = true;
                }
            }

            if (isClosing)
            {

                currentY += (float)gameTime.ElapsedGameTime.TotalSeconds * _openingSpeed;
                _currentRectangle.Y = (int)currentY;



                currentHeight -= (float)gameTime.ElapsedGameTime.TotalSeconds * 2 * _openingSpeed;
                _currentRectangle.Height = (int)currentHeight;


                if (_currentRectangle.Y >= WindowRectangle.Y + WindowRectangle.Height / 2 &&
                    _currentRectangle.Height <= 0)
                {
                    IsClosed = true;
                }
            }


        }

        public virtual void DrawContents(GameTime gameTime) { }

        public void Close()
        {
            isClosing = true;
            isOpen = false;
            isOpening = false;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void ToggleActive()
        {
            IsActive = !IsActive;
        }
    }
}
