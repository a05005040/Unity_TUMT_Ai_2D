using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;

    [Header("傷害"), Range(0, 100)]
    public float damge = 20;

    private Rigidbody2D r2d;
    public Transform checkpoint;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(checkpoint.position, -checkpoint.up * 3);
    }

    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {
        //r2d.AddForce(new Vector2(-speed, 0));    //世界座標
        r2d.AddForce(-transform.right*speed);       //區域座標
        RaycastHit2D hit= Physics2D.Raycast(checkpoint.position,- checkpoint.up, 1.5f, 1 << 8);
        if (hit==false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }


   /// <summary>
   /// 追蹤玩家
   /// </summary>
   /// <param name="target">玩家座標</param>
    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "狐狸")
        {
            collision.gameObject.GetComponent<Fox>().Damge(damge);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name =="狐狸"&&collision.transform.position.y<transform.position.y+1)
        {
            Track(collision.transform.position);
        }
        
    }
}
