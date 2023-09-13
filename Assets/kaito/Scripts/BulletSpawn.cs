using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�e���l�����ɔ��˂���G�̃X�N���v�g---
// \\�E�_�ŏ����ŃX�v���C�g�����_���[���I�t�ɂȂ��ʊO����ɂȂ��Ă��܂�
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // �e�v���n�u
    [SerializeField] float _bulletRotation; // �e�̉�]���
    SpriteRenderer _sr = null; // �X�v���C�g�����_���[
    [SerializeField] float _spawnTime; // �X�|�[������
    float _elapsedTime; // �o�ߎ���

    bool _isDead = false; // ���S����

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_isDead) // true�ɂȂ�����
        {
            return; // ����ȍ~�͌Ă΂�Ȃ�
        }

        Spawn();
    }

    // bullet�𐶐�����֐�
    void Spawn()
    {
        _elapsedTime += Time.deltaTime;

        // �o�ߎ��Ԃ��X�|�[�����ԁi�b�j���z������
        if (_elapsedTime > _spawnTime)
        {
            for (int i = 0; i < 4; i++) // �S��J��Ԃ�(�S����)
            {
                // �I�u�W�F�N�g�̈ʒu�ɒe�𐶐�(i * 90f�łS�����ɐ��������Ă���)
                Instantiate(_bulletPrefab, transform.position,
                    Quaternion.Euler(new Vector3(0f, 0f, i * 90f + _bulletRotation)));
            }
            _elapsedTime = 0; // �o�ߎ��ԃ��Z�b�g
        }
    }
}
