using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitBlocks : MonoBehaviour
{
    //private Grid grid;
    
    public int Width = 16;
    public int Height = 8;

    public Blocks[,] grid;
    
    public GameObject blockObject;
    public GameObject endGameObject;

    public TimeGestion time;
    public TextMeshPro dispTurn;
    public TextMeshPro dispScore;
    
    public ListBalls list;

    private System.Random ran = new System.Random();
    private void Start()
    {
        InitGrid();
        FirstBlocks();
        BlocksDisplay();
        //grid.TranslateNumber();

        time.actualizeTime = false;
        time.shotTime = true;
    }

    void Update()
    {
        if (time.actualizeTime)
        {
            //Afficher de nouveaux cubes en augmentant la difficulté
            
            ActualizeGrid();
            FirstBlocks();
            BlocksDisplay();

            time.turn += 1;
            time.actualizeTime = false;
            if (!time.endGame)
            {
                time.shotTime = true;
            }
            else
            {
                GameObject obj = Instantiate(endGameObject);
                
                obj.GetComponentInChildren<TextMeshPro>().SetText("Score = " + time.turn);
                
                //dispTurn.SetText("Score = " + time.turn);
            }
            
            dispTurn.SetText("Turn : " + time.turn);
        }
    }
    
    public void InitGrid()
    {
        grid = new Blocks[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                grid[i, j] = new Blocks();
            }
        }
    }
    
    public void FirstBlocks()
    {
        int i = 1;
        for (int j = 0; j < Width; j++)
        {
            if (ran.Next(1, 3) == 1)
            {
                Vector2 pos = new Vector2(j - 8, 4 - i);
                
                GameObject obj = Instantiate(blockObject,pos , new Quaternion());

                obj.GetComponent<BlockCollision>().list = list;
                
                grid[i, j] = new Blocks(obj, i, j);

                grid[i,j].number = ran.Next(time.turn + 1, time.turn + 3);
                
                grid[i,j].block.GetComponent<BlockCollision>().number = grid[i,j].number;
                grid[i,j].block.GetComponent<BlockCollision>().disp.SetText(""+grid[i,j].block.GetComponent<BlockCollision>().number);

                if (ran.Next(1, 10) == 1)
                {
                    grid[i,j].block.GetComponent<BlockCollision>().giveBall = true;
                    grid[i,j].block.GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
    }
    public void ActualizeGrid()
    {
        for (int i = Height-1; i > 0; i--)
        {
            for (int j = 0; j < Width; j++)
            {
                if (grid[i-1, j].present)
                {
                    if (grid[i - 1, j].block == null)
                    {
                        grid[i - 1, j] = new Blocks();
                        //Debug.Log(grid.grid[i-1,j].present);
                    }
                    else
                    {
                        grid[i, j] = grid[i-1, j];

                        grid[i - 1, j] = new Blocks();
                    
                        grid[i, j].pos.y -= 1;

                        if (i == Height - 1)
                        {
                            time.endGame = true;
                        }
                    
                        //Debug.Log(grid[i,j].present);
                    }
                }
            }
        }
    }
    public void BlocksDisplay()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (grid[i, j].block != null)
                {
                    grid[i, j].block.transform.position = new Vector3(grid[i, j].pos.x,grid[i, j].pos.y - 1,0);
                    //grid.grid[i,j].block = Instantiate(grid.grid[i,j].block, new Vector3(grid.grid[i,j].posX, grid.grid[i,j].posY, 0), new Quaternion());
                }
            }
        }
    }
}
