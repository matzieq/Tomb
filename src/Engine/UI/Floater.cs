using Microsoft.Xna.Framework;
using Tomb.Engine.Text;


namespace Tomb.Engine.UI
{
    // public class Floater : IEntity
    // {
    //     public string Contents;
    //     public Monster ParentMonster;
    //     public Vector2 Offset = new Vector2(4, -7);
    //     public bool IsMoving = false;
    //     float counter = 1.0f;
    //     public bool IsActive = true;

    //     public bool Finished
    //     {
    //         get
    //         {
    //             return counter <= 0;
    //         }
    //     }

    //     public Floater(string contents, Monster attachedTo, bool moving = false)
    //     {
    //         Contents = contents;
    //         ParentMonster = attachedTo;
    //         IsMoving = moving;
    //     }
    //     public void Draw(GameTime gameTime)
    //     {
    //         if (!Finished && IsActive)
    //         {
    //             TextUtils.DrawTextLine(Vector2.Round(ParentMonster.Position + Offset + ParentMonster.PositionVariation * 1.5f), Contents, true, true);
    //         }
    //     }

    //     public void Update(GameTime gameTime)
    //     {
    //         if (IsMoving && counter > 0)
    //         {
    //             Offset.Y -= counter / 4;
    //             counter -= (float)gameTime.ElapsedGameTime.TotalSeconds;
    //         }
    //     }

    //     public void Activate()
    //     {
    //         counter = 1.0f;
    //         IsActive = true;
    //         Offset = new Vector2(4, -7);
    //     }

    //     public void Deactivate()
    //     {
    //         counter = 0;
    //         IsActive = false;
    //     }
    // }
}