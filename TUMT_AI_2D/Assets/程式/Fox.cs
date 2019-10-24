using UnityEngine;

public class Fox : MonoBehaviour     //類別
{
    public int speed = 50;          //
    public float jump = 2.5f;
    public string foxname = "狐狸";
    public bool pass = false;
    private Rigidbody2D r2d;
    


    private void Start()             //開始事件       
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        //r2d.AddForce(new Vector2(speed, 0));
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);//A D 左右
    }
}
