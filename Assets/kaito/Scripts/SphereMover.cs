using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----オブジェクトを円周上で移動させるスクリプト----
public class SphereMover : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed; // 速度
    [SerializeField] float radius; // 半径

    float moveX;
    float moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation() // 回転処理についての関数
    {
        moveX = radius * Mathf.Cos(Time.time * speed);
        moveY = radius * Mathf.Sin(Time.time * speed);

        rb.MovePosition(new Vector2(moveX, moveY));
    }
}
