using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵から発射される弾のスクリプト----
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // 速度

    [HideInInspector] public Vector2 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0) * Time.deltaTime);
    }
}
