using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵から発射される弾のスクリプト----
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // 速度

    [HideInInspector] public Vector2 _startPos; // 初期位置

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0f) * Time.deltaTime);
    }
}
