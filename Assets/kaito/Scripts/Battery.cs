using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�e�𔭎˂���C��̃X�N���v�g---
public class Battery : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefabs;
    BatteryBullet _bulletControllerScript; // �e�̃X�N���v�g

    [SerializeField] float _startTime; // �����J�n����
    [SerializeField] float _spawnTime; // �X�|�[������
    [SerializeField] float _deleteBulletTime; // �e�̍폜����

    void Start()
    {
        _bulletControllerScript = GameObject.Find("BulletInTheBattery")
            .GetComponent<BatteryBullet>(); // �X�N���v�g�擾

        // ""���\�b�h��(_startTime)�b��Ɏ��s��A(_spawnTime)�b�Ԋu�Ŏ��s
        InvokeRepeating("InstantiateGameObject", _startTime, _spawnTime);
    }

    // �Q�[���I�u�W�F�N�g���C���X�^���X�����郁�\�b�h
    public void InstantiateGameObject()
    {
        var instance = Instantiate<GameObject>(_bulletPrefabs, _bulletControllerScript._startPos,
            _bulletPrefabs.transform.rotation);

        // �C���X�^���X�����I�u�W�F�N�g��(_deleteBulletTime)�b��ɏ���
        Destroy(instance, _deleteBulletTime);
    }
}
