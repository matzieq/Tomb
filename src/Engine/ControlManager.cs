using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Tomb.Engine
{
    public class ControlManager
    {
        static KeyboardState currentKeyState;
        static KeyboardState previousKeyState;
        static float _keyDownTime = 0;

        public static KeyboardState GetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            return currentKeyState;
        }

        public static bool IsPressed(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool JustPressed(Keys key)
        {
            if (_keyDownTime > 0.0f)
            {
                _keyDownTime = 0;
                return currentKeyState.IsKeyDown(key);
            }
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }

        public static void Update(GameTime gameTime, Game game)
        {
            _keyDownTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
           
            GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
        }

        public static Vector2 GetDirectionState()
        {
            var shouldResetKeyDownTime = true;

            var dir = Vector2.Zero;

            if (IsPressed(Keys.Up))
            {
                dir = Vector2.UnitY * -1;
                shouldResetKeyDownTime = false;
            }
            else if (IsPressed(Keys.Down))
            {
                dir = Vector2.UnitY;
                shouldResetKeyDownTime = false;
            }
            else if (IsPressed(Keys.Left))
            {
                dir = Vector2.UnitX * -1;
                shouldResetKeyDownTime = false;
            }
            else if (IsPressed(Keys.Right))
            {
                dir = Vector2.UnitX;
                shouldResetKeyDownTime = false;
            }
            if (shouldResetKeyDownTime)
            {
                _keyDownTime = 0.0f;
            }
            return dir;
        }
    }
}
