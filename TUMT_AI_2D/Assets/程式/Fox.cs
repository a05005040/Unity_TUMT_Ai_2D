using UnityEngine;

public class Fox : MonoBehaviour     //類別
{
    public int speed = 50;          //
    public float jump = 2.5f;
    public string foxname = "狐狸";
    public bool pass = false;
    private Rigidbody2D r2d;
    private Transform tra;


    private void Start()             //開始事件       
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) tra.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.A)) tra.eulerAngles = new Vector3(0, 180, 0);       //翻轉角度
    }
    private void FixedUpdate()
    {

        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
}
