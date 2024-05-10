using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tomb.Engine.Text;
// using Tomb.States;
// using Tomb.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tomb.Engine.UI
{
    public delegate void RemoveDelegate(Window window);
    class Hud
    {
        public static List<Window> windows = new List<Window>();

        public static bool isMinimapOn = false;

        public static void Initialize()
        {
            //var window = new Window(new Rectangle(10, 10, 100, 100), 1, RemoveWindow);
            //windows.Add(window);
        }

        public static void ToggleMinimap()
        {
            isMinimapOn = !isMinimapOn;
        }

        public static void Draw(GameTime gameTime)
        {
            if (isMinimapOn)
            {
                DrawMiniMap();
            }
            DrawHud(gameTime);
        }

        public static void Update(GameTime gameTime)
        {
            windows.ForEach(win => win.Update(gameTime));
            windows.RemoveAll(win => win.IsClosed);
        }

        static void DrawHud(GameTime gameTime)
        {
          
            // Globals.playingState.GlobalEffects.ForEach(effect => TextUtils.DrawTextLine(new Vector2(70, (++y * 10)), effect.Effect.ToString()));

            windows.ForEach(win => win.Draw(gameTime));

        }

        // public static void DrawHealth()
        // {
        //     Utils.DrawSprite(new Vector2(8, 8), TilesetManager.Quads[132], true, Color.White);
        //     TextUtils.DrawTextLine(
        //         new Vector2(18, 10),
        //         ((int)Globals.playingState.Player.HP).ToString() + "/" +
        //         ((int)Globals.playingState.Player.MaxHP).ToString() 
        //     );

        // }

        public static void RemoveWindow(Window window)
        {
            windows.Remove(window);
        }


        public static void CloseAllWindows()
        {
            foreach (var window in windows)
            {
                window.Close();
            }
        }

        public static void DrawMiniMap()
        {
         
                
            
        }
    }
}
