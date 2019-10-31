using UnityEngine;

public class Fox : MonoBehaviour     //類別
{
    public int speed = 50;          //
    public float jump = 2.5f;
    public string foxname = "狐狸";
    public bool pass = false;
    private Rigidbody2D r2d;
    private Transform tra;
    public bool isGround;


    private void Start()             //開始事件       
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }
    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
    private void FixedUpdate()
    {
        Jump();
        Walk();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到" + collision.gameObject);

    }

    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="Direction">方向 左轉為180 右轉為0</param>
    private void Turn(int Direction)
    {

        tra.eulerAngles = new Vector3(0, Direction, 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGround==true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }
}
