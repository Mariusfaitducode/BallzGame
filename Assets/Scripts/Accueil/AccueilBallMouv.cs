using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccueilBallMouv : MonoBehaviour
{
    public float SPEED = 20f;
    private System.Random ran = new System.Random();
    void Start()
    {
        ThrowBall();
    }

    public void ThrowBall()
    {
        Vector2 shotBall = new Vector2();

        shotBall.x = ran.Next(1,100) ;
        shotBall.y = ran.Next(1, 100);

        float magnitude = Mathf.Sqrt(Mathf.Pow(shotBall.x, 2) + Mathf.Pow(shotBall.y, 2));

        shotBall.x /=  magnitude;
        shotBall.y /=  magnitude;

        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().velocity =  SPEED * shotBall;
    }
}
