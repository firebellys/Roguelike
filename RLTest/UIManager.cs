using Microsoft.Xna.Framework;
using SadConsole;
namespace RLTest
{
    // Creates/Holds/Destroys all consoles used in the game
    // and makes consoles easily addressable from a central place.
    public class UIManager : ContainerConsole
    {
        public ScrollingConsole MapConsole;

        public UIManager()
        {
            // must be set to true
            // or will not call each child's Draw method
            IsVisible = true;
            IsFocused = true;

            // The UIManager becomes the only
            // screen that SadConsole processes
            Parent = SadConsole.Global.CurrentScreen;
        }

        public void CreateConsoles()
        {
            MapConsole = new SadConsole.ScrollingConsole(GameLoop.World.CurrentMap.Width, GameLoop.World.CurrentMap.Height, Global.FontDefault, new Rectangle(0, 0, GameLoop.GameWidth, GameLoop.GameHeight), GameLoop.World.CurrentMap.Tiles);
        }

  // centers the viewport camera on an Actor
        public void CenterOnActor(Actor actor)
        {
            MapConsole.CenterViewPortOnPoint(actor.Position);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            CheckKeyboard();
            base.Update(timeElapsed);
        }

        // Scans the SadConsole's Global KeyboardState and triggers behaviour
        // based on the button pressed.
        private void CheckKeyboard()
        {
            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Keyboard movement for Player character: Up arrow
            // Decrement player's Y coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                GameLoop.World.Player.MoveBy(new Point(0, -1));
                CenterOnActor(GameLoop.World.Player);
            }

            // Keyboard movement for Player character: Down arrow
            // Increment player's Y coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                GameLoop.World.Player.MoveBy(new Point(0, 1));
                CenterOnActor(GameLoop.World.Player);
            }

            // Keyboard movement for Player character: Left arrow
            // Decrement player's X coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                GameLoop.World.Player.MoveBy(new Point(-1, 0));
                CenterOnActor(GameLoop.World.Player);
            }

            // Keyboard movement for Player character: Right arrow
            // Increment player's X coordinate by 1
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                GameLoop.World.Player.MoveBy(new Point(1, 0));
                CenterOnActor(GameLoop.World.Player);
            }
        }
    }
}