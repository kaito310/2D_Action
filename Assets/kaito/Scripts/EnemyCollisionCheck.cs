using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�G���ǂ�G�ɓ������������肷��X�N���v�g---
public class EnemyCollisionCheck : MonoBehaviour
{
    [HideInInspector] public bool _isOn = false; // �����ɐڐG�������ǂ���

    string _wallTag = "Wall";
    string _enemyTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision) // �ڐG�����Ƃ�
    {
        // Wall�^�O��Enemy�^�O�����I�u�W�F�N�g�Ȃ�
        if (collision.tag == _wallTag || collision.tag == _enemyTag)
        {
            _isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // �ڐG���I�������
    {
        if (collision.tag == _wallTag || collision.tag == _enemyTag)
        {
            _isOn = false;
        }
    }
}
