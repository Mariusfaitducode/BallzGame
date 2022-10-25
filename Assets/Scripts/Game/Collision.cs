using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public TimeGestion time;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Base"))
        {
            if (!gameObject.tag.Equals("Player"))
            {
                Destroy(gameObject);
            }
            else
            {
                //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                time.actualizeTime = true;
            }
        }

        if (collision.gameObject.tag.Equals("Ball"))
        {
            //gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            //gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
/*
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Base"))
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }*/
}
