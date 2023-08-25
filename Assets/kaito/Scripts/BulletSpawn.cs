using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�e�̐������s���X�N���v�g---
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // �e�v���n�u

    [SerializeField] float _spawnBounds; // �X�|�[������
    [SerializeField] float _deleteTime; // �j��܂ł̎���
    float _elapsedTime; // �o�ߎ���

    BulletController bulletControllerScript; // bullet�̃X�N���v�g

    // Start is called before the first frame update
    void Start()
    {
        bulletControllerScript = GameObject.Find("bullet").GetComponent<BulletController>();
        Destroy(_bulletPrefab, _deleteTime); // deleteTime���ɒe���폜
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        _elapsedTime += Time.deltaTime;

        // �G�����݂���Ƃ��A���o�ߎ��Ԃ��X�|�[�����ԁi�b�j���z������
        if (gameObject && _elapsedTime > _spawnBounds)
        {
            Instantiate(_bulletPrefab, bulletControllerScript._startPos, _bulletPrefab.transform.rotation); // �X�^�[�g�ʒu�ɒe�𐶐�
            
            _elapsedTime = 0; // �o�ߎ��ԃ��Z�b�g
        }
        if (_elapsedTime == _deleteTime)
        {
            
        }
    }
}
