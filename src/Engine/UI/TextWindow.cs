using System;
using Microsoft.Xna.Framework;
using Tomb.Engine.Text;

namespace Tomb.Engine.UI
{
    public class TextWindow : Window
    {
        public string[] TextLines;

        public TextWindow(string[] textLines, Rectangle windowPos) : base(windowPos, 2)
        {
            TextLines = textLines;
        }

        public override void DrawContents(GameTime gameTime)
        {
            TextUtils.DrawParagraph(Position + new Vector2(8, 8), TextLines);
        }
    }
}
