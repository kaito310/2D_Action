using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵から発射される弾のスクリプト----
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // 速度
    [SerializeField] float _deleteTime; // 破壊までの時間

    void Start()
    {
        Destroy(gameObject, _deleteTime); // _deleteTime(秒)で削除
    }

    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーかステージに当たったら消す
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Stage"))
        {
            Destroy(gameObject);
        }
    }
}
