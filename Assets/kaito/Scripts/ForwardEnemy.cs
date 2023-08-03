using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�G�����E�Ɉړ�������X�N���v�g----
public class ForwardEnemy : MonoBehaviour
{
    Vector2 pos;

    [SerializeField] float _speed; // �ړ����x
    [SerializeField] int _num = 1; // ���E�ړ��؂�ւ��p�̕ϐ�
    [SerializeField] float _xBounds; // x�������̈ړ��͈̔�

    // Update is called once per frame
    void Update()
    {
        pos = transform.position; // ���݂̍��W�ʒu�擾
        
        if (pos.x > _xBounds)
        {
            _num = -1; // ���Ɉړ�������悤��
        }
        if (pos.x < -_xBounds)
        {
            _num = 1; // �E�Ɉړ�������悤��
        }

        // _num���}�C�i�X�ɂȂ�Ƌt�����Ɉړ�����
        transform.Translate(transform.right * Time.deltaTime * _speed * _num);
    }
}
