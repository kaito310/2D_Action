using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�C�䂩�甭�˂����e�̃X�N���v�g---
public class BatteryBullet : MonoBehaviour
{
    [SerializeField] float _speed; // ����
    int _frameCount; // �t���[���J�E���g
    const int _deleteFrame = 180; // �폜�t���[��

    void Start()
    {
        
    }

    void Update()
    {
        // �ʒu�̍X�V
        transform.Translate(_speed * Time.deltaTime, 0, 0);

        // ���t���[���ŏ���
        if (++_frameCount > _deleteFrame)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[���X�e�[�W�ɓ������������
        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Stage"))
        {
            Destroy(gameObject);
        }
    }
}
