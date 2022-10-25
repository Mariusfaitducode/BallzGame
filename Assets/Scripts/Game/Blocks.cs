using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks
{
    public int number;
    private Color color;
    
    public Vector2 pos;
    
    public bool present;
    public GameObject block;

    public Blocks()
    {
        present = false;
    }

    public Blocks(GameObject block, int i, int j)
    {
        this.block = block;
        pos = new Vector2(j - 8, 4 - i);
        present = true;
    }

    public void DescentBlock()
    {
        pos.x += 1;
    }

    public void SetPosition(int i, int j)
    {
        pos.x = j - 8;
        pos.y = 4 - i;
    }

    
}
