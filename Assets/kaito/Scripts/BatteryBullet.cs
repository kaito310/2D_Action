using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�C�䂩�甭�˂����e�̃X�N���v�g---
public class BatteryBullet : MonoBehaviour
{
    [SerializeField] float _speed; // ����
    //[HideInInspector] public Vector2 _startPos; // �����ʒu
    [SerializeField] float _deleteTime; // �ꔭ�ڂ̒e����������

    void Start()
    {
        //_startPos = transform.position;
        Destroy(gameObject, _deleteTime);
    }

    void Update()
    {
        // �ʒu�̍X�V
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[���X�e�[�W�ɓ������������
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Stage") || collision.gameObject.CompareTag("HiddenWall"))
        {
            Destroy(gameObject);
        }
    }
}
