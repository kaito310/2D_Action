using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オブジェクトを円周上で移動させるスクリプト

public class SphereMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f; // 移動速度
    [SerializeField] float circle_radius = 1.0f;
    Vector2 initPosition; // 初期位置固定

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Circle();
    }

    void Circle()
    {
        Vector2 pos = transform.position;

        float rad = moveSpeed * Mathf.Rad2Deg * Time.time;

        pos.x = Mathf.Cos(rad) * circle_radius;

        transform.position = pos;
    }
}
