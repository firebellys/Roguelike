using System;
using Microsoft.Xna.Framework;
using SadConsole;

namespace RLTest
{
    class GameObjects
    {

    }

    public abstract class TileBase : Cell
    {

        // Movement and Line of Sight Flags
        public bool IsBlockingMove;
        public bool IsBlockingLOS;

        // Tile's name
        protected string Name;

        // TileBase is an abstract base class 
        // representing the most basic form of of all Tiles used.
        // Every TileBase has a Foreground Colour, Background Colour, and Glyph
        // IsBlockingMove and IsBlockingLOS are optional parameters, set to false by default
        public TileBase(Color foreground, Color background, int glyph, bool blockingMove = false, bool blockingLOS = false, String name = "") : base(foreground, background, glyph)
        {
            IsBlockingMove = blockingMove;
            IsBlockingLOS = blockingLOS;
            Name = name;
        }
    }

    public class TileWall : TileBase
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default
        // and have a light gray foreground and a transparent background
        // represented by the # symbol
        public TileWall(bool blocksMovement = true, bool blocksLOS = true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
    public class TileFloor : TileBase
    {
        // Default constructor
        // Floors are set to allow movement and line of sight by default
        // and have a dark gray foreground and a transparent background
        // represented by the . symbol
        public TileFloor(bool blocksMovement = false, bool blocksLOS = false) : base(Color.DarkGray, Color.Transparent, '.', blocksMovement, blocksLOS)
        {
            Name = "Floor";
        }
    }

    public class Map
    {
        TileBase[] _tiles; // contain all tile objects
        private int _width;
        private int _height;

        public TileBase[] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }

        //Build a new map with a specified width and height
        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            Tiles = new TileBase[width * height];
        }

        public bool IsTileWalkable(Point location)
        {
            // first make sure that actor isn't trying to move
            // off the limits of the map
            if (location.X < 0 || location.Y < 0 || location.X >= Width || location.Y >= Height)
                return false;
            // then return whether the tile is walkable
            return !_tiles[location.Y * Width + location.X].IsBlockingMove;
        }
    }

    public abstract class Actor : SadConsole.Entities.Entity
    {
        private int _health; //current health
        private int _maxHealth; //maximum possible health

        public int Health
        {
            get
            {
                return ((_health / _maxHealth) * 100); // returns current health as a percentage of maxHealth
            }
            set
            {
                _health = value;
            }
        }
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } } // public setter for current health

        protected Actor(Color foreground, Color background, int glyph, int width = 1, int height = 1) : base(width, height)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }
        // Moves the Actor BY positionChange tiles in any X/Y direction
        // returns true if actor was able to move, false if failed to move
        public bool MoveBy(Point positionChange)
        {
            // Check the map if we can move to this new position
            if (GameLoop.GameMap.IsTileWalkable(Position + positionChange))
            {
                Position += positionChange;
                return true;
            }
            else
                return false;
        }


        // Moves the Actor TO newPosition location
        // returns true if actor was able to move, false if failed to move
        public bool MoveTo(Point newPosition)
        {
            Position = newPosition;
            return true;
        }
    }
    public class Player : Actor
    {
        public Player(Color foreground, Color background) : base(foreground, background, '@')
        {

        }
    }
}
