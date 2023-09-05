using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---弾を四方向に発射する敵のスクリプト---
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // 弾プレハブ
    SpriteRenderer _sr = null;
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
        if (_sr.isVisible) // 画面内なら
        {
            _elapsedTime += Time.deltaTime;

            // 経過時間がスポーン時間（秒）を越えたら
            if (_elapsedTime > _spawnTime)
            {
                for (int i = 0; i < 4; i++) // ４回繰り返す(４つ生成)
                {
                    // オブジェクトの位置に弾を生成(i * 90fで４方向に生成させている)
                    Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, i * 90f)));
                }
                _elapsedTime = 0; // 経過時間リセット
            }
        }
    }

}
