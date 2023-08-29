using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�G���甭�˂����e�̃X�N���v�g----
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // ���x

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
