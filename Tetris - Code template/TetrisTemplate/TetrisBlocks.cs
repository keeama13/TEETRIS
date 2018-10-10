using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public class TetrisBlocks
{
    public bool[,] curBool;
    public Color curColor;
    public static TetrisBlocks curBlock;
    Vector2 Location;
    public TetrisBlocks(Vector2 Location)
    {
        this.Location = Location;
    }
     
}

public class BlockI : TetrisBlocks
{
    public BlockI(Vector2 Location) : base(Location)
    {
        curColor = Color.LightBlue;
        curBool = new bool[4, 4]
        {
            {false, false, true, false},
            {false, false, true, false},
            {false, false, true, false},
            {false, false, true, false},
        };
    }
}

public class Square : TetrisBlocks
{
    public Square(Vector2 Location) : base(Location)
    {
        curColor = Color.Yellow;
        curBool = new bool[2, 2]
        {
            {true, true},
            {true, true},
        };
    }
}

public class BlockZ : TetrisBlocks
{
    public BlockZ(Vector2 Location) : base(Location)
    {
        curColor = Color.Green;
        curBool = new bool[3, 3]
        {
            {false, false, false},
            {true,  true,  false},
            {false, true,  true},

        };
    }
}

public class BlockS : TetrisBlocks
{
    public BlockS(Vector2 Location) : base(Location)
    {
        curColor = Color.Red;
        curBool = new bool[3, 3]
        {
            {false, false, false},
            {false, true,  true},
            {true,  true,  false},
        };
    }
}

public class BlockL : TetrisBlocks
{
    public BlockL(Vector2 Location) : base(Location)
    {
        curColor = Color.Orange;
        curBool = new bool[3, 3]
        {
            {false, true, false},
            {false, true, false},
            {false, true, true},

        };
    }
}

public class BlockInvL : TetrisBlocks
{
    public BlockInvL(Vector2 Location) : base(Location)
    {
        curColor = Color.Blue;
        curBool = new bool[3, 3]
        {
            {false, true, false},
            {false, true, false},
            {true, true, false},
            
        };
    }
}

public class BlockT : TetrisBlocks
{
    public BlockT(Vector2 Location) : base(Location)
    {
        curColor = Color.Purple;
        curBool = new bool[3, 3]
        {
            {false, false, false},
            {false, true,  false},
            {true,  true,  true},

        };

    }
}

