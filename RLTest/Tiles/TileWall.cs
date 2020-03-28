using System;
using Microsoft.Xna.Framework;
namespace SalvageGame.Tiles
{
    // TileWall is based on TileBase
    // Walls are to be used in maps.
    public class TileWall : TileBase
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default
        // and have a dark gray foreground and a transparent background
        // represented by the # symbol
        public TileWall(bool blocksMovement = true, bool blocksLOS = true, int glyph = '#') : base(Color.LightGray, Color.Transparent, glyph, blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
    // TileWall is based on TileBase
    // Walls are to be used in maps.
    public class TileWallSolid : TileBase
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default
        // and have a dark gray foreground and a transparent background
        // represented by the # symbol
        public TileWallSolid(bool blocksMovement = true, bool blocksLOS = true, int glyph = '#') : base(Color.LightGray, Color.DarkGray, glyph, blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
}
