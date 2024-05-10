using System;
using Microsoft.Xna.Framework.Audio;

namespace Tomb.Engine
{
    public class SoundManager
    {
        public static SoundEffect Walk;
        public static SoundEffect Hit;
        public static SoundEffect Powerup;

        public static void Init()
        {
            Walk = Globals.Content.Load<SoundEffect>("walk");
            Hit = Globals.Content.Load<SoundEffect>("hit");
            Powerup = Globals.Content.Load<SoundEffect>("Powerup");
        }
    }
}
