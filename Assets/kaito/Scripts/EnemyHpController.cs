using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---敵が受けるダメージ処理のスクリプト---
public class EnemyHpController : MonoBehaviour
{
    [SerializeField] int _hp;
    bool _isHit = false; // 攻撃を受けたか
    [HideInInspector] bool _isDead = false; // 消滅判定

    [SerializeField] float _flashInterval;// 点滅間隔
    [SerializeField] int _loopCount; // 点滅時のループカウント
    SpriteRenderer _sr; // 点滅させるためのSpriteRenderer
    BoxCollider2D _bc2d; // コライダーのオン・オフを切り替えるための変数
    Material _color; // オブジェクトに付与している色

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bc2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (_hp == 0) // HPが0になったら
        {
            Destroy(gameObject);
            _isDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 攻撃を受けているか、消滅したらこれ以降の処理を行わない
        if (_isHit || _isDead)
        {
            return;
        }

        // プレイヤーの弾か剣の判定に当たったら
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _hp--;
            _isHit = true;
        }

        // コルーチン開始
        StartCoroutine(Damage());
        Debug.Log("コルーチン開始");
    }

    // 点滅させる処理
    IEnumerator Damage()
    {
        _sr.color = Color.black; // 色を黒にする

        // 点滅ループ開始
        for (int i = 0; i < _loopCount; i++)
        {
            // _flashInterval(秒)待ってから
            yield return new WaitForSeconds(_flashInterval);
            _sr.enabled = false; // spriteRendererをオフ

            yield return new WaitForSeconds(_flashInterval);
            _sr.enabled = true;
        }

        //---(色を元に戻す)---

        // 点滅ループから抜けたら
        _isHit = false;
    }
}
