using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---弾を発射する砲台のスクリプト---
public class Battery : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // 弾プレハブ
    SpriteRenderer _sr = null; // スプライトレンダラー
    [SerializeField] float _spawnTime; // スポーン時間
    float _elapsedTime; // 経過時間

    bool _isDead = false; // 死亡判定

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_isDead) // trueになったら
        {
            return; // これ以降は呼ばれない
        }

        Spawn();
    }

    // bulletを生成する関数
    void Spawn()
    {
        _elapsedTime += Time.deltaTime;

        // 経過時間がスポーン時間（秒）を越えたら
        if (_elapsedTime > _spawnTime)
        {
            // オブジェクトの位置に弾を生成
            Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);

            _elapsedTime = 0; // 経過時間リセット
        }
    }
}
