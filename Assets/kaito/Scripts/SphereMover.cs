using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�I�u�W�F�N�g���~����ňړ�������X�N���v�g----
public class SphereMover : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float _speed; // ���x
    [SerializeField] float _radius; // ���a

    float moveX;
    float moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation() // ��]�����ɂ��Ă̊֐�
    {
        moveX = _radius * Mathf.Cos(Time.time * _speed);
        moveY = _radius * Mathf.Sin(Time.time * _speed);

        rb.MovePosition(new Vector2(moveX, moveY));
    }
}
