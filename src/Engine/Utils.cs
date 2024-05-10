using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tomb.Engine
{
    public enum Dice
    {
        None = 1,
        D2 = 2,
        D3 = 3,
        D4 = 4,
        D5 = 5,
        D6 = 6,
        D8 = 8,
        D100 = 100
    }

    

    public static class Utils
    {
        public static Random Random = new Random();

        public static Game Game;

        
        public static Vector2[] Directions = new Vector2[] {
            new Vector2(-1, 0),
            new Vector2(1, 0),
            new Vector2(0, -1),
            new Vector2(0, 1)
        };

        public static Vector2[] DirectionsWithDiagonals = new Vector2[] {
            new Vector2(-1, 0),
            new Vector2(1, 0),
            new Vector2(0, -1),
            new Vector2(0, 1),
            new Vector2(1, -1),
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(-1, -1)
        };

        public static void Initialize(Game game)
        {
            Game = game;
        }

        public static double GetRandomDoubleFromRange(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }

        public static int GetRandomIntFromRange(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public static int RollDice(Dice dice, int modifier = 0)
        {
            return GetRandomIntFromRange(1, (int)dice) + modifier;
        }

        public static void DrawSprite(Vector2 position, Rectangle quad, bool flipped, Color tint)
        {
            Globals.spriteBatch.Draw(TilesetManager.Tileset, position, quad, tint, 0, new Vector2(4, 4), new Vector2(1, 1), flipped ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
        }

        public static void DrawSprite(Vector2 position, int quad, bool flipped, Color tint)
        {
            Globals.spriteBatch.Draw(TilesetManager.Tileset, position, TilesetManager.Quads[quad], tint, 0, new Vector2(4, 4), new Vector2(1, 1), flipped ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
        }



        public static void QuitGame()
        {
            Game.Exit();
        }
    }
}
