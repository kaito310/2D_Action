using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�G���܂������ړ�������X�N���v�g---
public class MoveForward : MonoBehaviour
{
    // sprite�������_�����O���A�V�[����łǂ̂悤�ɕ\�����邩�𐧌䂷��R���|�[�l���g
    SpriteRenderer _sr = null;
    Rigidbody2D _rb = null;

    // �ڐG����̃X�N���v�g�i���T�C�h��HitBox��t���Ă��邽�߁A�z����g�p�j
    [SerializeField] EnemyCollisionCheck[] _checkCollision;

    [SerializeField] float _speed; // �ړ����x
    bool _rightTleftF = false; // �ړ������̃`�F�b�N�ifalse�ō��j

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        //_checkCollision = GameObject.Find("HitBox").GetComponent<EnemyCollisionCheck>();
    }

    // ���b�����ƂɌĂ΂��
    void FixedUpdate()
    {
        Forward();
    }

    int _xVector = -1; // �ړ������ύX�p�̕ϐ��i-1�ō��Ɉړ��j
    void Forward() // �G�̓����̊֐�
    {
        if (_sr.isVisible) // ��ʂɉf���Ă���Ȃ�
        {
            if (_checkCollision[0]._isOn || _checkCollision[1]._isOn) // ���E�ǂ��炩�̐ڐG���肪true�ɂȂ�����
            {
                _rightTleftF = !_rightTleftF; // �^�U���t�ɂ���ifalse�Ȃ�true�Ɂj
            }

            if (_rightTleftF) // true�Ȃ�
            {
                _xVector = 1; // �E�Ɉړ�
            }
            else // false�Ȃ�
            {
                _xVector = -1; // ���Ɉړ�
            }
            _rb.velocity = new Vector2(_xVector * _speed, 0) * Time.deltaTime;
        }
        else // ��ʊO�Ȃ�
        {
            _rb.Sleep(); // �������Z���ꎞ�I�ɓ������Ȃ�����
        }
    }
}
