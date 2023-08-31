using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---弾を発射する砲台のスクリプト---
public class Battery : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    Vector3 _bulletPoint; // 生成位置

    float _elapsedTime; // 経過時間
    [SerializeField] float _spawnTime; // スポーン時間

    void Start()
    {
        // 親オブジェクトからの相対位置
        _bulletPoint = transform.Find("BulletPoint").localPosition;
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_spawnTime > _elapsedTime)
        {
            // プレイヤー位置に生成
            Instantiate(_bulletPrefab, transform.position + _bulletPoint, Quaternion.identity);

            _elapsedTime = 0;
        }
    }

}
