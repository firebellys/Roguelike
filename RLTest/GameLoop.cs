using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SadConsole.Components;

namespace RLTest
{
    class GameLoop
    {
   public const int Width = 80;
        public const int Height = 25;
        private static Player player;

        public static Map GameMap;
        private static int _mapWidth = 100;
        private static int _mapHeight = 100;
        private static int _maxRooms = 500;
        private static int _minRoomSize = 4;
        private static int _maxRoomSize = 15;
private static ScrollingConsole startingConsole;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Setup the engine and creat the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        //private static void Update(GameTime time)
        //{
        //    CheckKeyboard();
        //}

        /// <summary>
        /// 
        /// </summary>
        private static void Init()
        {
            // Initialize an empty map
            GameMap = new Map(_mapWidth, _mapHeight);
        // Instantiate a new map generator and
            // populate the map with rooms and tunnels
            MapGenerator mapGen = new MapGenerator();
            GameMap = mapGen.GenerateMap(_mapWidth, _mapHeight, _maxRooms, _minRoomSize, _maxRoomSize);
            // Create a console using gameMap's tiles
            startingConsole = new ScrollingConsole(GameMap.Width, GameMap.Height, Global.FontDefault, new Rectangle(0, 0, Width, Height), GameMap.Tiles);

            startingConsole.ViewPort = new Rectangle(0, 0, Width - 10, Height - 10);
            // Set our new console as the thing to render and process
            SadConsole.Global.CurrentScreen = startingConsole;

            // create an instance of player
            CreatePlayer();

            // add the player Entity to our only console
            // so it will display on screen
            player.Components.Add(new EntityViewSyncComponent());
            startingConsole.Children.Add(player);
        }

        //public static void CenterOnActor(Actor actor)
        //{
        //    startingConsole.CenterViewPortOnPoint(actor.Position);
        //}

        // Scans the SadConsole's Global KeyboardState and triggers behaviour
        // based on the button pressed.
        //private static void CheckKeyboard()
        //{
        //    // Keyboard movement for Player character: Up arrow
        //    // Decrement player's Y coordinate by 1
        //    if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
        //    {
        //        player.MoveBy(new Point(0, -1));
        //        CenterOnActor(player);
        //    }

        //    // Keyboard movement for Player character: Down arrow
        //    // Increment player's Y coordinate by 1
        //    if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
        //    {
        //        player.MoveBy(new Point(0, 1));
        //        CenterOnActor(player);
        //    }

        //    // Keyboard movement for Player character: Left arrow
        //    // Decrement player's X coordinate by 1
        //    if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
        //    {
        //        player.MoveBy(new Point(-1, 0));
        //        CenterOnActor(player);
        //    }

        //    // Keyboard movement for Player character: Right arrow
        //    // Increment player's X coordinate by 1
        //    if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
        //    {
        //        player.MoveBy(new Point(1, 0));
        //        CenterOnActor(player);
        //    }
        //}

        // Create a player using SadConsole's Entity class
        private static void CreatePlayer()
        {
            player = new Player(Color.Yellow, Color.Transparent);
            player.Position = new Point(5,5);
        }

        //private static void CreateWalls()
        //{
        //    // Create an empty array of tiles that is equal to the map size
        //    _tiles = new TileBase[Width * Height];

        //    //Fill the entire tile array with floors
        //    for (int i = 0; i < _tiles.Length; i++)
        //    {
        //        _tiles[i] = new TileWall();
        //    }
        //}

        //public bool IsTileWalkable(Point location)
        //{
        //    // first make sure that actor isn't trying to move
        //    // off the limits of the map
        //    if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
        //        return false;
        //    // then return whether the tile is walkable
        //    return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        //}

        //private static void CreateFloors()
        //{
        //    //Carve out a rectangle of floors in the tile array
        //    for (int x = 0; x < _roomWidth; x++)
        //    {
        //        for (int y = 0; y < _roomHeight; y++)
        //        {
        //            // Calculates the appropriate position (index) in the array
        //            // based on the y of tile, width of map, and x of tile
        //            _tiles[y * Width + x] = new TileFloor();
        //        }
        //    }
        //}
    }
}