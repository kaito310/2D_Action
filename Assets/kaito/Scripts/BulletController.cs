using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵から発射される弾のスクリプト----
/* ・弾の現在位置（移動中の位置）に生成されてしまう
   ・破壊できていない */
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // 速度
    [SerializeField] GameObject parentEnemy;
    [SerializeField] GameObject bulletPrefab;
    
    float elapsedTime; // 経過時間
    [SerializeField] float timeBounds; // 時間上限
    [SerializeField] float deleteTime; // 破壊までの時間

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0f) * Time.deltaTime);
        Shooting();
    }

    void Shooting() // 敵が弾を発射する関数
    {
        elapsedTime += Time.deltaTime; // 毎Fの時間を足していく

        // 親オブジェクトが存在するとき、かつ経過時間が時間上限（秒）を越えたら
        if (parentEnemy && elapsedTime > timeBounds)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation); // 弾を生成

            elapsedTime = 0; // 経過時間リセット
        }

        if (elapsedTime == deleteTime) // 経過時間が破壊時間を越えたら
        {
            Debug.Log("a");
            Destroy(gameObject);
        }
    }
}
