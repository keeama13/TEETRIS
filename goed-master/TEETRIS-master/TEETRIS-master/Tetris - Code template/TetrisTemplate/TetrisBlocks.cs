using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

public class TetrisBlocks
{
    public bool[,] curBool;
    public Color curColor;
    public static TetrisBlocks curBlock;
    public Vector2 Location;

    public TetrisBlocks(Vector2 Location)
    {
        this.Location = Location;
    }

    public TetrisBlocks GetRandomBlock(int x)
    {

        switch (x)
        {
            case 0:
                return new BlockI(new Vector2(3, -4));
            case 1:
                return new Square(new Vector2(5, -2));
            case 2:
                return new BlockS(new Vector2(4, -3));
            case 3:
                return new BlockZ(new Vector2(4, -3));
            case 4:
                return new BlockT(new Vector2(4, -3));
            case 5:
                return new BlockL(new Vector2(4, -3));
            default:
                return new BlockInvL(new Vector2(4, -3));
        }
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

