using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----壁に衝突時にバウンドさせるスクリプト----
public class Bounce : MonoBehaviour
{
    [SerializeField] Vector2 _velocity; // 速度

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = _velocity;
    }

    // リジッドボディの付いているオブジェクトに当たると跳ね返る
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityNext = Vector2.Reflect(_velocity, collision.contacts[0].normal);
        _velocity = velocityNext;
    }
}
