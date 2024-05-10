using System;
using Microsoft.Xna.Framework;

namespace Tomb.Engine
{
    public enum WindowSizes
    {
        Small,
        Medium,
        Large
    }

    public class ScreenManager
    {
        public static int NativeWidth { get; set; } = 192;
        public static int NativeHeight { get; set; } = 160;

        static readonly int[] _windowWidthset = new int[] { 576, 960, 1280 };
        static readonly int[] _windowHeightset = new int[] { 480, 800, 1080 };

        public static int WindowWidth { get => _windowWidthset[(int)CurrentSize]; }
        public static int WindowHeight { get => _windowHeightset[(int)CurrentSize]; }
        public static WindowSizes CurrentSize { get; private set; } = WindowSizes.Medium;

        public static void SetWindowSize(WindowSizes windowSize, GraphicsDeviceManager graphics)
        {
            CurrentSize = windowSize;
            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.ApplyChanges();
        }

        public static void ToggleScreenSize(GraphicsDeviceManager graphics)
        {
            if (CurrentSize == WindowSizes.Small)
            {
                SetWindowSize(WindowSizes.Medium, graphics);
            }
            else if (CurrentSize == WindowSizes.Medium)
            {
                SetWindowSize(WindowSizes.Large, graphics);
            }
            else if (CurrentSize == WindowSizes.Large)
            {
                graphics.IsFullScreen = true;
                graphics.ApplyChanges();
            }
            else if (graphics.IsFullScreen)
            {
                SetWindowSize(WindowSizes.Small, graphics);
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
            }
        }
    }
}
