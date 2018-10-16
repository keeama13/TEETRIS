using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

/// <summary>
/// A class for representing the game world.
/// This contains the grid, the falling block, and everything else that the player can see/do.
/// </summary>
class GameWorld
{
    //known bugs lange ding doet het niet in de linker twee velden
    //rotaten aan rechterkant gaat fout
    
    /// <summary>
    /// An enum for the different game states that the game can have.
    /// </summary>
    enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    /// <summary>
    /// The random-number generator of the game.
    /// </summary>
    public static Random Random { get { return random; } }
    static Random random;
    
    
	/// <summary>
    /// The main font of the game.
    /// </summary>
    SpriteFont font;

    /// <summary>
    /// The current game state.
    /// </summary>
    GameState gameState;

    /// <summary>
    /// The main grid of the game.
    /// </summary>
    TetrisGrid grid;
    TetrisBlocks block = new TetrisBlocks(Vector2.Zero);
    public int blockWidth;
    public int blockHeight;
    public List<TetrisBlocks> blockList;
    bool update = false;
    int speed;

    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;

        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");
        speed = 15;
        grid = new TetrisGrid();        
        block = block.GetRandomBlock(random.Next(0,7));
        //block = new BlockI(new Vector2(4, -4));
        blockWidth = block.curBool.GetLength(1);
        blockHeight = block.curBool.GetLength(0);
        blockList = new List<TetrisBlocks>();

    }
    //new BlockI(Vector2.Zero);


    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Left))
        {
            if(block.Location.X > 0 - LeftClear())
                block.Location.X--;
            
        }
        if (inputHelper.KeyPressed(Keys.Right))
        {
            if(block.Location.X + blockWidth < grid.Width + RightClear())
                block.Location.X++;
        }
        if(inputHelper.KeyPressed(Keys.Space))
        {
            do
            {
                block.Location.Y += 1;
            }
            while (NoCollision());
        }
        if (inputHelper.KeyDown(Keys.I))
        {
            speed = 5;
        }
        else
        {
            speed = 15;
        }
        if (inputHelper.KeyPressed(Keys.A))
        {
            if (LeftClear() > 0 && block.Location.X - LeftClear() < 0)
            {
                block.Location.X += LeftClear();
            }
            if (RightClear() > 0 && block.Location.X + blockWidth - RightClear() > grid.Width - 1)
            {
                block.Location.X -= RightClear();
            }
            block.curBool = Rotate(block.curBool, false);

        }
        if (inputHelper.KeyPressed(Keys.D))
        {
            if (LeftClear() > 0 && block.Location.X - LeftClear() < 0)
            {
                block.Location.X += LeftClear();
            }
            if (RightClear() > 0 && block.Location.X + blockWidth - RightClear() > grid.Width - 1)
            {
                block.Location.X -= RightClear();
            }
            block.curBool = Rotate(block.curBool, true);

        }




    }

    bool[,] Rotate(bool[,] block, bool whichWay) //rotate an array (true is right and false is left)
    {
        bool[,] Rotated = new bool[blockHeight, blockWidth];

        for (int i = 0; i < blockHeight; ++i)
        {
            for (int j = 0; j < blockWidth; ++j)
            {
                if (whichWay)
                    Rotated[i, j] = block[blockWidth - j - 1, i];
                else
                    Rotated[i, j] = block[j, blockWidth - i - 1];
            }
        }
        return Rotated;
    }

    public void CheckScore()
    {

    }



    public bool NoCollision()
    {
        
        for (int h = blockHeight - 1; h >= 0; h--)
        {
            for (int j = 0; j < blockWidth; j++)
            {
                if (block.curBool[h, j] && block.Location.Y + h + 1 >= grid.Height)
                {
                    AddBlock(blockWidth,blockHeight);
                    block = block.GetRandomBlock(random.Next(0,7));
                    //block = new BlockI(new Vector2(4, -4));
                    update = true;
                    
                    return false;

                }
                if (block.Location.Y + h >= 0 && block.Location.X - LeftClear() + j >= 0 && block.Location.Y + h + 1 <= grid.Height && block.Location.X + j <= grid.Width) //alleen de waardes binnen de grid moeten worden gecheckt
                {
                        if (block.curBool[h, j] && grid.grid[(int)block.Location.Y + h + 1, (int)block.Location.X + j])
                        {
                            AddBlock(blockWidth, blockHeight);
                            block = block.GetRandomBlock(random.Next(0, 7));
                            //block = new BlockI(new Vector2(4, -4));
                            update = true;
                            return false;
                        }
                }
                

            }
        }
        return true;
    }

    public int LeftClear()
    {
        int amount = 0;
        for(int x = 0; x < blockHeight; x++)
        {
            for (int y = 0; y < blockHeight; y++)
            {
                if(block.Location.X < grid.Width)
                    if (block.curBool[y, x])
                    {
                        return amount;
                    }
            }
            amount++;
        }
        return amount;
    }

    public int RightClear() //amount of columns that is free on the right side inside the block
    {
        int amount = 0;
        for (int x = blockWidth - 1; x > 0; x--)
        {
            for (int y = 0; y < blockHeight; y++)
            {
                if (block.Location.X > 0)
                {
                    if (block.curBool[y, x])
                    {
                        return amount;
                    }
                }
                
            }
            amount++;

        }
        return amount;
    }
       
        
    


    public void AddBlock(int x, int y)
    {
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                if (block.curBool[i, j] && block.Location.Y >= 0 && block.Location.X + j >= 0 && block.Location.Y + i <= grid.Height && block.Location.X + j <= grid.Width)
                {
                    grid.grid[(int)block.Location.Y + i, (int)block.Location.X+j] = true;
                }
            }
        }
    }

   

    public void Update(GameTime gameTime)
    {
        if (update)
        {
            blockWidth = block.curBool.GetLength(0);
            blockHeight = block.curBool.GetLength(1);
           
            update = false;
        }
    }

    public void DrawBlocks(SpriteBatch spriteBatch, TetrisBlocks block)
    {
        
        for (int a = 0; a < blockHeight; a++)
        {
            for (int b = 0; b < blockWidth; b++)
            {

                if (block.curBool[a, b] && a >= 0 && b >= 0 && a <= grid.Height && b <= grid.Width)
                {
                    spriteBatch.Draw(grid.emptyCell, new Vector2((b + block.Location.X) * grid.emptyCell.Width, (a + block.Location.Y) * grid.emptyCell.Height), block.curColor);
                }
            }
        }
    }




    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "Score:", new Vector2(100, 0), Color.Blue);

        DrawBlocks(spriteBatch, this.block);

        grid.tijd++;
        if (NoCollision())
        {
            
            if (grid.tijd == 10)
            {
                block.Location.Y += 1;
                grid.tijd = 0;
                

                //NoCollision();
            }

        }
        spriteBatch.End();
        
    }

    public void Reset()
    {

    }

    

}
