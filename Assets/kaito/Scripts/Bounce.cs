using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�ǂɏՓˎ��Ƀo�E���h������X�N���v�g----
public class Bounce : MonoBehaviour
{
    [SerializeField] Vector2 _velocity; // ���x

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = _velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityNext = Vector2.Reflect(_velocity, collision.contacts[0].normal);
        _velocity = velocityNext;
    }

}
