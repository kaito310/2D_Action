using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----足場を上下に動かすスクリプト----
public class MoveY_axis : MonoBehaviour
{
    [SerializeField] float _length; // 往復範囲
    float moveY; // y軸方向の値

    // Update is called once per frame
    void Update()
    {
        // 往復した値を時間から計算
        moveY = Mathf.PingPong(Time.time, _length);

        // y座標を往復させて上下に動かす
        transform.localPosition = new Vector2(transform.position.x, moveY);
    }
}
