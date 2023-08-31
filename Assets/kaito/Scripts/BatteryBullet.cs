using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---砲台から発射される弾のスクリプト---
public class BatteryBullet : MonoBehaviour
{
    [SerializeField] float _speed; // 速さ
    int _frameCount; // フレームカウント
    const int _deleteFrame = 180; // 削除フレーム

    void Start()
    {
        
    }

    void Update()
    {
        // 位置の更新
        transform.Translate(_speed * Time.deltaTime, 0, 0);

        // 一定フレームで消す
        if (++_frameCount > _deleteFrame)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーかステージに当たったら消す
        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Stage"))
        {
            Destroy(gameObject);
        }
    }
}
