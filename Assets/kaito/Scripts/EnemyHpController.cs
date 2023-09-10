using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---敵が受けるダメージ処理のスクリプト---
public class EnemyHpController : MonoBehaviour
{
    [SerializeField] int _hp; // 敵のHP
    bool _isHit = false; // 攻撃を受けたか
    [HideInInspector] bool _isDead = false; // 消滅判定

    [SerializeField] float _flashInterval;// 点滅間隔
    [SerializeField] int _loopCount; // 点滅時のループカウント
    SpriteRenderer _sr; // 点滅させるためのSpriteRenderer

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 攻撃を受けているか、消滅したらこれ以降の処理を行わない
        if (_isHit || _isDead)
        {
            return;
        }

        // プレイヤーの弾か剣の判定に当たったら
        if (collider.gameObject.CompareTag("Bullet") || collider.gameObject.CompareTag("Slash"))
        {
            _hp--;
            _isHit = true;

            if (_hp <= 0) // HPが0以下になったら
            {
                _isDead = true;
                Destroy(gameObject);
                return;
            }

            // コルーチン開始
            StartCoroutine(Damage());
        }
    }

    // 点滅させる処理
    IEnumerator Damage()
    {
        Debug.Log("コルーチン開始");
        if (_isHit) // 攻撃を受けたら
        {
            // 点滅ループ開始
            for (int i = 0; i < _loopCount; i++)
            {
                // _flashInterval(秒)待ってから
                yield return new WaitForSeconds(_flashInterval);
                _sr.enabled = false; // spriteRendererをオフ

                yield return new WaitForSeconds(_flashInterval);
                _sr.enabled = true;
            }

            // 点滅ループから抜けたら
            _isHit = false;
        }
    }
}
