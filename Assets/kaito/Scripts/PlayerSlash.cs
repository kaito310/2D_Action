using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�v���C���[�L�����̌��̔���̃X�N���v�g---
public class PlayerSlash : MonoBehaviour
{
    PlayerController _playerControllerScript;
    SpriteRenderer p_Sr;
    bool _srCheck; // �v���C���[�̌���

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        p_Sr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _srCheck = p_Sr.flipX;
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
            Debug.Log("�\��");
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
