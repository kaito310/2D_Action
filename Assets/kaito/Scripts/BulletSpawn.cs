using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---弾の生成を行うスクリプト---
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // 弾プレハブ

    [SerializeField] float _spawnBounds; // スポーン時間
    [SerializeField] float _deleteTime; // 破壊までの時間
    float _elapsedTime; // 経過時間

    BulletController bulletControllerScript; // bulletのスクリプト

    // Start is called before the first frame update
    void Start()
    {
        bulletControllerScript = GameObject.Find("bullet").GetComponent<BulletController>();
        Destroy(_bulletPrefab, _deleteTime); // deleteTime毎に弾を削除
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        _elapsedTime += Time.deltaTime;

        // 敵が存在するとき、かつ経過時間がスポーン時間（秒）を越えたら
        if (gameObject && _elapsedTime > _spawnBounds)
        {
            Instantiate(_bulletPrefab, bulletControllerScript._startPos, _bulletPrefab.transform.rotation); // スタート位置に弾を生成
            
            _elapsedTime = 0; // 経過時間リセット
        }
        if (_elapsedTime == _deleteTime)
        {
            
        }
    }
}
