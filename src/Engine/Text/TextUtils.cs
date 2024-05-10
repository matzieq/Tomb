using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Tomb.Engine.Text
{
    public class TextUtils
    {

        public static Dictionary<char, int> CharCodes = new Dictionary<char, int>()
        {
            {'A', 0 },
            {'B', 1 },
            {'C', 2 },
            {'D', 3 },
            {'E', 4 },
            {'F', 5 },
            {'G', 6 },
            {'H', 7 },
            {'I', 8 },
            {'J', 9 },
            {'K', 10 },
            {'L', 11 },
            {'M', 12 },
            {'N', 13 },
            {'O', 14 },
            {'P', 15 },
            {'Q', 16 },
            {'R', 17 },
            {'S', 18 },
            {'T', 19 },
            {'U', 20 },
            {'V', 21 },
            {'W', 22 },
            {'X', 23 },
            {'Y', 24 },
            {'Z', 25 },
            {'.', 26 },
            {'\'', 27 },
            {'!', 28 },
            {'?', 29 },
            {':', 30 },
            {';', 31 },
            {',', 32 },
            {' ', 35 },
            {'/', 38 },
            {'0', 125 },
            {'1', 126 },
            {'2', 127 },
            {'3', 128 },
            {'4', 129 },
            {'5', 138 },
            {'6', 139 },
            {'7', 140 },
            {'8', 141 },
            {'9', 142 }
        };

        public static void DrawTextLine(Vector2 position, string text, bool isActive = true, bool shadowText = false)
        {
            var chars = text.ToUpper().ToCharArray();

            var currentX = 0;

            foreach (var singleChar in chars)
            {
                if (CharCodes.ContainsKey(singleChar))
                {
                    var charCode = CharCodes[singleChar];

                    if (shadowText)
                    {
                        foreach (var dir in Utils.DirectionsWithDiagonals)
                        {
                            Utils.DrawSprite(
                                        position + new Vector2(currentX, 0) + dir,
                                        TilesetManager.Quads[charCode],
                                        true,
                                        Color.Black);
                            Utils.DrawSprite(
                                        position + new Vector2(currentX, 0) + dir * 2,
                                        TilesetManager.Quads[charCode],
                                        true,
                                        Color.Black);
                        }
                    }
                    Utils.DrawSprite( 
                                    position + new Vector2(currentX, 0), 
                                    TilesetManager.Quads[charCode], 
                                    true, 
                                    isActive ? Color.White : Color.Gray);
                    currentX += 4;
                }
            }
        }

       

        public static void DrawParagraph(Vector2 position, string[] paragraph, bool shadowText = false)
        {
            var currentY = 0;
            foreach (var line in paragraph)
            {
                DrawTextLine(position + new Vector2(0, currentY), line, true, shadowText);
                currentY += 6;
            }
        }
    }
}
