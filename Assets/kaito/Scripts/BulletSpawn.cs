using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�e�̐������s���X�N���v�g---
//---�C����---
public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab; // �e�v���n�u
    BulletController _bulletControllerScript;
    SpriteRenderer _sr = null;

    [SerializeField] float _spawnTime; // �X�|�[������
    [SerializeField] float _deleteTime; // �j��܂ł̎���
    float _elapsedTime; // �o�ߎ���

    bool _isDead = false; // ���S����

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bulletControllerScript = GameObject.Find("bullet").GetComponent<BulletController>();
        //\\�G���[�ӏ� //Destroy(_bulletPrefab, _deleteTime); // deleteTime���ɒe���폜

    }

    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (_sr.isVisible) // ��ʓ��Ȃ�
        {
            _elapsedTime += Time.deltaTime;

            // �o�ߎ��Ԃ��X�|�[�����ԁi�b�j���z������
            if (_elapsedTime > _spawnTime)
            {
                // �X�^�[�g�ʒu�ɒe�𐶐�
                Instantiate(_bulletPrefab, _bulletControllerScript._startPos, _bulletPrefab.transform.rotation);

                Debug.Log("�R���[�`������");
                yield return new WaitForSeconds(_spawnTime); // n�b��~

                _elapsedTime = 0; // �o�ߎ��ԃ��Z�b�g
            }

            if (_isDead) // true�ɂȂ�����
            {
                Debug.Log("�R���[�`����~");
                yield break; // �R���[�`����~
            }
        }
    }

}
