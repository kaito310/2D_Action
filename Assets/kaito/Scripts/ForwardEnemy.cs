using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵を左右に移動させるスクリプト----
public class ForwardEnemy : MonoBehaviour
{
    Vector2 pos;

    [SerializeField] float _speed; // 移動速度
    [SerializeField] int _num = 1; // 左右移動切り替え用の変数
    [SerializeField] float _xBounds; // x軸方向の移動の範囲

    // Update is called once per frame
    void Update()
    {
        pos = transform.position; // 現在の座標位置取得
        
        if (pos.x > _xBounds)
        {
            _num = -1; // 左に移動させるように
        }
        if (pos.x < -_xBounds)
        {
            _num = 1; // 右に移動させるように
        }

        // _numがマイナスになると逆方向に移動する
        transform.Translate(transform.right * Time.deltaTime * _speed * _num);
    }
}
