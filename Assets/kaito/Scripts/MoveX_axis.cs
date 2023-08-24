using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�I�u�W�F�N�g�����E�Ɉړ�������X�N���v�g----
public class MoveX_axis : MonoBehaviour
{
    [SerializeField] float _speed; // �ړ����x
    [SerializeField] int _num = 1; // ���E�ړ��؂�ւ��p�̕ϐ�
    [SerializeField] float _xBounds; // x�������̈ړ��͈̔�

    Vector2 startPos; // �����ʒu
    Vector2 pos; // ���݈ʒu

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        // ���݈ʒu�������ʒu�{�ړ��͈͂��傫���Ȃ�����
        if (pos.x > startPos.x + _xBounds && _num == 1)
        {
            _num = -1; // ���Ɉړ�������悤��
        }
        if (pos.x < (startPos.x - _xBounds) && _num == -1)
        {
            _num = 1; // �E�Ɉړ�������悤��
        }

        // _num���}�C�i�X�ɂȂ�Ƌt�����Ɉړ�����
        transform.Translate(transform.right * Time.deltaTime * _speed * _num);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �ǂɏՓˎ��Ɍ����ύX�p
        if (collision.gameObject.CompareTag("Wall") && _num == -1)
        {
            _num = 1;
        }
        if (collision.gameObject.CompareTag("Wall") && _num == 1)
        {
            _num = -1;
        }
    }
}