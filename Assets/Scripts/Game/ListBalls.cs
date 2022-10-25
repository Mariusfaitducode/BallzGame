using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListBalls : MonoBehaviour
{
    public GameObject firstBall;
    public List<GameObject> listBalls = new List<GameObject>();

    public int countBalls;
    
    public GameObject ballToAdd;
    
    public TextMeshPro ballsNumber;

    public void AddBall(Vector3 pos)
    {
        //GameObject ball = Instantiate(ballToAdd, pos, new Quaternion());
        //GameObject ball = Instantiate(ballToAdd);
        
        //ball.GetComponent<Renderer>().material.color = Color.green;
        
        //listBalls.Add(ballToAdd);
        //ballsNumber.SetText("Balls : "+ listBalls.Count);
    }
}
