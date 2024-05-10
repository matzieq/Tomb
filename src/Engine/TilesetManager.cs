using System; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Tomb.Engine
{
    public class TilesetManager
    {
        public static Texture2D Tileset;

        public static int TileSize = 8;

        public static List<Rectangle> Quads;

        public static void Initialize(int tileSize)
        {
            
            Tileset = Globals.Content.Load<Texture2D>("tileset");
            Globals.tileset = Tileset;
            TileSize = tileSize;
            GenerateQuads();
        }

        static void GenerateQuads()
        {
            Quads = new List<Rectangle>();
            for (int y = 0; y < Tileset.Height; y += TileSize)
            {
                for (int x = 0; x < Tileset.Width; x += TileSize)
                {
                    Quads.Add(new Rectangle(x, y, TileSize, TileSize));
                }
            }
        }
    }
}
