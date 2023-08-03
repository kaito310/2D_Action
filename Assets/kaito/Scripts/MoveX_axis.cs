using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----足場を左右に動かすスクリプト----
public class MoveX_axis : MonoBehaviour
{
    [SerializeField] float _length; // 往復範囲
    float moveX; // x軸方向の値

    // Update is called once per frame
    void Update()
    {
        // 往復した値を時間から計算
        moveX = Mathf.PingPong(Time.time, _length);

        // x座標を往復させて左右に動かす
        transform.localPosition = new Vector2(moveX, transform.position.y);
    }
}
