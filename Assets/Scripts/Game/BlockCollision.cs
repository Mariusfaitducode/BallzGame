using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public int number;
    public TextMeshPro disp;

    public bool giveBall;
    

    public ListBalls list;
    //public ThrowBall listRef;

    public void Start()
    {
        //list = listRef.list;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        number -= 1;
        disp.SetText(""+number);
        if (number <= 0)
        {
            if (giveBall)
            {
                list.countBalls += 1;
                list.ballsNumber.SetText("Balls : "+ list.countBalls);
            }
            
            Destroy(gameObject);

            //list.AddBall(gameObject.transform.position);
            //print(list.listBalls.Count);
            
        }
/*
        if (!collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }*/
    }
}
