using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----オブジェクトを上下に動かすスクリプト----
public class MoveY_axis : MonoBehaviour
{
    [SerializeField] float _speed; // 移動速度
    [SerializeField] int _num = 1; // 左右移動切り替え用の変数
    [SerializeField] float _yBounds; // y軸方向の移動の範囲

    Vector2 startPos; // 初期位置
    Vector2 pos; // 現在位置

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        // 現在位置が初期位置＋移動範囲より大きくなったら
        if (pos.y > startPos.y + _yBounds)
        {
            _num = -1; // 下に移動させるように
        }
        if (pos.y < (startPos.y - _yBounds))
        {
            _num = 1; // 上に移動させるように
        }

        // _numがマイナスになると逆方向に移動する
        transform.Translate(transform.up * Time.deltaTime * _speed * _num);
    }
}
