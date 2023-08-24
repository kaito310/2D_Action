using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----オブジェクトを左右に移動させるスクリプト----
public class MoveX_axis : MonoBehaviour
{
    [SerializeField] float _speed; // 移動速度
    [SerializeField] int _num = 1; // 左右移動切り替え用の変数
    [SerializeField] float _xBounds; // x軸方向の移動の範囲

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
        if (pos.x > startPos.x + _xBounds && _num == 1)
        {
            _num = -1; // 左に移動させるように
        }
        if (pos.x < (startPos.x - _xBounds) && _num == -1)
        {
            _num = 1; // 右に移動させるように
        }

        // _numがマイナスになると逆方向に移動する
        transform.Translate(transform.right * Time.deltaTime * _speed * _num);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 壁に衝突時に向き変更用
        if (collision.gameObject.CompareTag("Wall") && _num == -1)
        {
            _num = 1;
        }
        if (collision.gameObject.CompareTag("Wall") && _num == 1)
        {
            _num = -1;
        }
    }
}