using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�I�u�W�F�N�g���㉺�ɓ������X�N���v�g----
public class MoveY_axis : MonoBehaviour
{
    [SerializeField] float _speed; // �ړ����x
    [SerializeField] int _num = 1; // ���E�ړ��؂�ւ��p�̕ϐ�
    [SerializeField] float _yBounds; // y�������̈ړ��͈̔�

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
        if (pos.y > startPos.y + _yBounds)
        {
            _num = -1; // ���Ɉړ�������悤��
        }
        if (pos.y < (startPos.y - _yBounds))
        {
            _num = 1; // ��Ɉړ�������悤��
        }

        // _num���}�C�i�X�ɂȂ�Ƌt�����Ɉړ�����
        transform.Translate(transform.up * Time.deltaTime * _speed * _num);
    }
}
