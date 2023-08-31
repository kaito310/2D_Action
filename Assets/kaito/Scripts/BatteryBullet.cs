using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�C�䂩�甭�˂����e�̃X�N���v�g---
public class BatteryBullet : MonoBehaviour
{
    [SerializeField] float _speed; // ����
    [HideInInspector] public Vector2 _startPos; // �����ʒu

    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        // �ʒu�̍X�V
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[���X�e�[�W�ɓ������������
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
