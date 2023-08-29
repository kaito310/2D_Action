using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---弾の生成を行うスクリプト---
//---修正中---
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // 弾プレハブ
    BulletController _bulletControllerScript;
    SpriteRenderer _sr = null;

    [SerializeField] float _spawnTime; // スポーン時間
    [SerializeField] float _deleteTime; // 破壊までの時間
    float _elapsedTime; // 経過時間

    bool _isDead = false; // 死亡判定

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bulletControllerScript = GameObject.Find("bullet").GetComponent<BulletController>();
        //\\エラー箇所 //Destroy(_bulletPrefab, _deleteTime); // deleteTime毎に弾を削除

    }

    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (_sr.isVisible) // 画面内なら
        {
            _elapsedTime += Time.deltaTime;

            // 経過時間がスポーン時間（秒）を越えたら
            if (_elapsedTime > _spawnTime)
            {
                // スタート位置に弾を生成
                Instantiate(_bulletPrefab, _bulletControllerScript._startPos, _bulletPrefab.transform.rotation);

                Debug.Log("コルーチン発動");
                yield return new WaitForSeconds(_spawnTime); // n秒停止

                _elapsedTime = 0; // 経過時間リセット
            }

            if (_isDead) // trueになったら
            {
                Debug.Log("コルーチン停止");
                yield break; // コルーチン停止
            }
        }
    }

}
