using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�G���甭�˂����e�̃X�N���v�g----
/*�E�j��ł��Ă��Ȃ� */
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // ���x
    [SerializeField] GameObject _parentEnemy; // �e�I�u�W�F�N�g
    [SerializeField] GameObject _bulletPrefab; // �e�v���n�u

    Vector2 _startPos; // �����ʒu
    
    [SerializeField] float _spawnBounds; // ���ԏ��
    [SerializeField] float _deleteTime; // �j��܂ł̎���
    float _elapsedTime; // �o�ߎ���

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting() // �G���e�𔭎˂���֐�
    {
        transform.Translate(new Vector2(_velocity, 0f) * Time.deltaTime);
        _elapsedTime += Time.deltaTime; // ��F�̎��Ԃ𑫂��Ă���

        // �e�I�u�W�F�N�g�����݂���Ƃ��A���o�ߎ��Ԃ��X�|�[�����ԁi�b�j���z������
        if (_parentEnemy && _elapsedTime > _spawnBounds)
        {
            Instantiate(_bulletPrefab, _startPos, transform.rotation); // �X�^�[�g�ʒu�ɒe�𐶐�

            _elapsedTime = 0; // �o�ߎ��ԃ��Z�b�g
        }
        if (_elapsedTime == _deleteTime)
        {
            Destroy(gameObject);
        }
    }
}
