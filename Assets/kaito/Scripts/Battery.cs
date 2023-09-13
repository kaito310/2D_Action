using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�e�𔭎˂���C��̃X�N���v�g---
public class Battery : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // �e�v���n�u
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
            // �I�u�W�F�N�g�̈ʒu�ɒe�𐶐�
            Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);

            _elapsedTime = 0; // �o�ߎ��ԃ��Z�b�g
        }
    }
}
