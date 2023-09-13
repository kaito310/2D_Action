using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�G���X�e�[�W�⑼�̓G�ɓ������������肷��X�N���v�g---
public class EnemyCollisionCheck : MonoBehaviour
{
    [HideInInspector] public bool _isOn = false; // �����ɐڐG�������ǂ���

    string _stageTag = "Stage";
    string _enemyTag = "Enemy";
    string _wallTag = "HiddenWall";
    string _playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision) // �ڐG�����Ƃ�
    {
        // Stage�^�O��Enemy�^�O��HiddenWall�^�O��Player�^�O�����I�u�W�F�N�g�Ȃ�
        if (collision.tag == _stageTag || collision.tag == _enemyTag || collision.tag == _wallTag || collision.tag == _playerTag)
        {
            _isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // �ڐG���I�������
    {
        if (collision.tag == _stageTag || collision.tag == _enemyTag || collision.tag == _wallTag)
        {
            _isOn = false;
        }
    }
}
