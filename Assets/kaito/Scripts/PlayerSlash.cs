using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�v���C���[�L�����̌��̔���̃X�N���v�g---
public class PlayerSlash : MonoBehaviour
{
    PlayerController _playerControllerScript;
    [SerializeField] BoxCollider2D _bo2d; // �R���C�_�[�̕\���E��\���ύX�p
    [SerializeField] GameObject _player;
    float _offset; // �v���C���[�ʒu����̑��΋����iy���W�j

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        _offset = transform.position.y - _player.transform.position.y;
    }

    void Update()
    {
        Slash();
    }

    // ����̕\���E��\����؂�ւ���֐�
    void Slash()
    {
        Vector2 _pos = transform.position; // �I�u�W�F�N�g�̍��W��ϐ��Ɉ�U�i�[
        // y���W�ɕϐ�_offset�̒l�������A�ϐ�_pos��y���W�ɑ��
        _pos.y = _player.transform.position.y + _offset;
        transform.position = _pos; // �ϐ�_pos�̒l���I�u�W�F�N�g���W�Ɋi�[

        if (!_playerControllerScript.isDead)
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
}
