using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---砲台から発射される弾のスクリプト---
public class BatteryBullet : MonoBehaviour
{
    [SerializeField] float _speed; // 速さ
    //[HideInInspector] public Vector2 _startPos; // 初期位置
    [SerializeField] float _deleteTime; // 一発目の弾を消す時間

    void Start()
    {
        //_startPos = transform.position;
        Destroy(gameObject, _deleteTime);
    }

    void Update()
    {
        // 位置の更新
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーかステージに当たったら消す
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stage") || collision.gameObject.CompareTag("HiddenWall"))
        {
            Destroy(gameObject);
        }
    }
}
