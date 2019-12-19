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
        r2d.AddForce(new Vector2(-speed, 0));
    }
    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {

    }
}
