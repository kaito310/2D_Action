using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�v���C���[�L�����̌��̔���̃X�N���v�g---
public class PlayerSlash : MonoBehaviour
{
    PlayerController _playerControllerScript;
    [SerializeField] BoxCollider2D _bo2d; // �R���C�_�[�̕\���E��\���ύX�p

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
    }

    void Update()
    {
        Slash();
    }

    // ����̕\���E��\����؂�ւ���֐�
    void Slash()
    {
        // �e���擾���Ă��Ȃ����AW�L�[�������Ă����
        if (_playerControllerScript.isGun == false && Input.GetKey(KeyCode.W))
        {
            _bo2d.enabled = true; // �R���C�_�[���擾
        }
        else
        {
            _bo2d.enabled = false;
        }
    }
}
