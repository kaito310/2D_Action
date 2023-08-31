using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---敵をまっすぐ移動させるスクリプト---
public class MoveForward : MonoBehaviour
{
    // spriteをレンダリングし、シーン上でどのように表示するかを制御するコンポーネント
    SpriteRenderer _sr = null;
    Rigidbody2D _rb = null;

    // 接触判定のスクリプト（両サイドにHitBoxを付けているため、配列を使用）
    [SerializeField] EnemyCollisionCheck[] _checkCollision;

    [SerializeField] float _speed; // 移動速度
    bool _rightTleftF = false; // 移動方向のチェック（falseで左）

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        //_checkCollision = GameObject.Find("HitBox").GetComponent<EnemyCollisionCheck>();
    }

    // 一定秒数ごとに呼ばれる
    void FixedUpdate()
    {
        Forward();
    }

    int _xVector = -1; // 移動方向変更用の変数（-1で左に移動）
    void Forward() // 敵の動きの関数
    {
        if (_sr.isVisible) // 画面に映っているなら
        {
            if (_checkCollision[0]._isOn || _checkCollision[1]._isOn) // 左右どちらかの接触判定がtrueになったら
            {
                _rightTleftF = !_rightTleftF; // 真偽を逆にする（falseならtrueに）
            }

            if (_rightTleftF) // trueなら
            {
                _xVector = 1; // 右に移動
            }
            else // falseなら
            {
                _xVector = -1; // 左に移動
            }
            _rb.velocity = new Vector2(_xVector * _speed, 0) * Time.deltaTime;
        }
        else // 画面外なら
        {
            _rb.Sleep(); // 物理演算を一時的に働かせなくする
        }
    }
}
