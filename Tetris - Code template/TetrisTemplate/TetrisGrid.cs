using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

/// <summary>
/// A class for representing the Tetris playing grid.
/// </summary>
class TetrisGrid
{
    static TetrisBlocks GetRandomBlock(int random)
    {
        switch (random)
        {
            case 0:
                return new BlockI(Vector2.Zero);
            case 1:
                return new Square(Vector2.Zero);
            case 2:
                return new BlockS(Vector2.Zero);
            case 3:
                return new BlockZ(Vector2.Zero);
            case 4:
                return new BlockT(Vector2.Zero);
            case 5:
                return new BlockL(Vector2.Zero);
            default:
                return new BlockInvL(Vector2.Zero);
        }
    }
    
    static TetrisBlocks block = GetRandomBlock(GameWorld.Random.Next(0, 7));
    int blockWidth = block.curBool.GetLength(0);
    int blockHeight = block.curBool.GetLength(1);
    public int BlockOffsetW = 0;
    float BlockOffsetH = 0f;
    int tijd = 0;
    

    //block = new Blocks(Content);
    /// The sprite of a single empty cell in the grid.
    Texture2D emptyCell;

    /// The position at which this TetrisGrid should be drawn.
    Vector2 position;

    
    /// The number of grid elements in the x-direction.
    public int Width { get { return 10; } }
    
    /// The number of grid elements in the y-direction.
    public int Height { get { return 20; } }

    
    /// <summary>
    /// Creates a new TetrisGrid.
    /// </summary>
    /// <param name="b"></param>
    public TetrisGrid()
    {
        emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
        position = new Vector2(0, 0);
        Clear();
    }
    public void Reset() 
    {

        
    }
    public bool Achterstevoren()
    {
        for (int h = blockHeight-1; h >= 0; h--)
        {
            for (int j = blockWidth-1; j >= 0; j--)
            {
                if (block.curBool[j,h] && (BlockOffsetH)*emptyCell.Height >= TetrisGame.ScreenSize.Y-blockHeight*emptyCell.Height) 
                {
                    block = GetRandomBlock(GameWorld.Random.Next(0, 7));
                    
                    return false;
                    
                }
      
            }
        }
        return true;
    }
    /// <summary>
    /// Draws the grid on the screen.
    /// </summary>
    /// <param name="gameTime">An object with information about the time that has passed in the game.</param>
    /// <param name="spriteBatch">The SpriteBatch used for drawing sprites and text.</param>
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        
        for(int z = 0; z < Height; z++)
        {
            for (int i = 0; i < Width; i++)
            {     
                spriteBatch.Draw(emptyCell, new Vector2(i * emptyCell.Width, z * emptyCell.Height), Color.White);
            }
        }
        for (int a = 0; a < blockHeight; a++)
        {
            for (int b = 0; b < blockWidth; b++)
            {
                if (block.curBool[a, b])
                {
                    spriteBatch.Draw(emptyCell, new Vector2((b + BlockOffsetW) * emptyCell.Width, (a + BlockOffsetH) * emptyCell.Height), block.curColor);
                }
                if (Achterstevoren())
                {
                    b = 0;
                    a = 0;
                }
            }
        }
        tijd++;
        if (Achterstevoren())
        {
            if (tijd == 30)
            {
                BlockOffsetH += 1;
                tijd = 0;
                //Achterstevoren();
            }

        }
        //Achterstevoren();
        //if(Vector2((b + BlockOffsetW) * emptyCell.Width, (a + BlockOffsetH) * emptyCell.Height))
    }
    
    /// <summary>
    /// Clears the grid.
    /// </summary>
    public void Clear()
    {
    }
}

