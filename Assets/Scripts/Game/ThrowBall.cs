using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;

public class ThrowBall : MonoBehaviour
{
    private Camera cam;
    public float SPEED = 20f;

    public TimeGestion time;

    public ListBalls list;

    public GameObject ball;

    void Start()
    {
        cam = Camera.main;
        //list = new ListBalls(gameObject);
    }
    async void Update()
    {
        if (time.shotTime)
        {
            throwBall();
            
        }
    }
    async public void throwBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 shotBall = new Vector2();

            Vector2 point = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector2 ballPos = gameObject.transform.position;

            shotBall.x = point.x - ballPos.x ;
            shotBall.y = point.y - ballPos.y ;

            float magnitude = Mathf.Sqrt(Mathf.Pow(shotBall.x, 2) + Mathf.Pow(shotBall.y, 2));

            shotBall.x /=  magnitude;
            shotBall.y /=  magnitude;

            print(point.x+ " // " + point.y);

            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().velocity =  SPEED * shotBall;

            Vector2 velo = GetComponent<Rigidbody2D>().velocity;
            
            time.shotTime = false;

            int max = list.countBalls;

            for (int i = 0; i < max; i++)
            {
                print("throwB2");
                await Task.Delay(100);
                GameObject obj = Instantiate(ball, ballPos, new Quaternion());
                obj.GetComponent<Rigidbody2D>().velocity = velo;
                print(obj);
            }
            
            /*foreach (GameObject var in list.listBalls)
            {
                //StartCoroutine(ThrowListBalls(var, ballPos, velo));
                
                print("throwB2");
                await Task.Delay(100);
                GameObject obj = Instantiate(var, ballPos, new Quaternion());
                obj.GetComponent<Rigidbody2D>().velocity = velo;
                print(obj);
            }*/
        }
    }
/*
    IEnumerator ThrowListBalls(GameObject var, Vector2 ballPos, Vector2 velo)
    {
        print("throwB");
        //yield return new WaitForSeconds(0.1f);
        
        GameObject obj = Instantiate(var, ballPos, new Quaternion());
        obj.GetComponent<Rigidbody2D>().velocity = velo;
        print(obj);
    }*/
}
