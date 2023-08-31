using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---弾を発射する砲台のスクリプト---
public class Battery : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefabs;
    BatteryBullet _bulletControllerScript; // 弾のスクリプト

    [SerializeField] float _startTime; // 生成開始時間
    [SerializeField] float _spawnTime; // スポーン時間
    [SerializeField] float _deleteBulletTime; // 弾の削除時間

    void Start()
    {
        _bulletControllerScript = GameObject.Find("BulletInTheBattery")
            .GetComponent<BatteryBullet>(); // スクリプト取得

        // ""メソッドを(_startTime)秒後に実行後、(_spawnTime)秒間隔で実行
        InvokeRepeating("InstantiateGameObject", _startTime, _spawnTime);
    }

    // ゲームオブジェクトをインスタンス化するメソッド
    public void InstantiateGameObject()
    {
        var instance = Instantiate<GameObject>(_bulletPrefabs, _bulletControllerScript._startPos,
            _bulletPrefabs.transform.rotation);

        // インスタンスしたオブジェクトを(_deleteBulletTime)秒後に消す
        Destroy(instance, _deleteBulletTime);
    }
}
