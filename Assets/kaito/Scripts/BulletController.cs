using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵から発射される弾のスクリプト----
/*・破壊できていない */
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // 速度
    [SerializeField] GameObject _parentEnemy; // 親オブジェクト
    [SerializeField] GameObject _bulletPrefab; // 弾プレハブ

    Vector2 _startPos; // 初期位置
    
    [SerializeField] float _spawnBounds; // 時間上限
    [SerializeField] float _deleteTime; // 破壊までの時間
    float _elapsedTime; // 経過時間

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting() // 敵が弾を発射する関数
    {
        transform.Translate(new Vector2(_velocity, 0f) * Time.deltaTime);
        _elapsedTime += Time.deltaTime; // 毎Fの時間を足していく

        // 親オブジェクトが存在するとき、かつ経過時間がスポーン時間（秒）を越えたら
        if (_parentEnemy && _elapsedTime > _spawnBounds)
        {
            Instantiate(_bulletPrefab, _startPos, transform.rotation); // スタート位置に弾を生成

            _elapsedTime = 0; // 経過時間リセット
        }
        if (_elapsedTime == _deleteTime)
        {
            Destroy(gameObject);
        }
    }
}
