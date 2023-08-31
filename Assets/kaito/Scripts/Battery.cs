using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�e�𔭎˂���C��̃X�N���v�g---
public class Battery : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    Vector3 _bulletPoint; // �����ʒu

    float _elapsedTime; // �o�ߎ���
    [SerializeField] float _spawnTime; // �X�|�[������

    void Start()
    {
        // �e�I�u�W�F�N�g����̑��Έʒu
        _bulletPoint = transform.Find("BulletPoint").localPosition;
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_spawnTime > _elapsedTime)
        {
            // �v���C���[�ʒu�ɐ���
            Instantiate(_bulletPrefab, transform.position + _bulletPoint, Quaternion.identity);

            _elapsedTime = 0;
        }
    }

}
