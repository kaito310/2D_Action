using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�G���󂯂�_���[�W�����̃X�N���v�g---
public class EnemyHpController : MonoBehaviour
{
    [SerializeField] int _hp; // �G��HP
    bool _isHit = false; // �U�����󂯂���
    [HideInInspector] bool _isDead = false; // ���Ŕ���

    [SerializeField] float _flashInterval;// �_�ŊԊu
    [SerializeField] int _loopCount; // �_�Ŏ��̃��[�v�J�E���g
    SpriteRenderer _sr; // �_�ł����邽�߂�SpriteRenderer

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // �U�����󂯂Ă��邩�A���ł����炱��ȍ~�̏������s��Ȃ�
        if (_isHit || _isDead)
        {
            return;
        }

        // �v���C���[�̒e�����̔���ɓ���������
        if (collider.gameObject.CompareTag("Bullet") || collider.gameObject.CompareTag("Slash"))
        {
            _hp--;
            _isHit = true;

            if (_hp <= 0) // HP��0�ȉ��ɂȂ�����
            {
                _isDead = true;
                Destroy(gameObject);
                return;
            }

            // �R���[�`���J�n
            StartCoroutine(Damage());
        }
    }

    // �_�ł����鏈��
    IEnumerator Damage()
    {
        Debug.Log("�R���[�`���J�n");
        if (_isHit) // �U�����󂯂���
        {
            // �_�Ń��[�v�J�n
            for (int i = 0; i < _loopCount; i++)
            {
                // _flashInterval(�b)�҂��Ă���
                yield return new WaitForSeconds(_flashInterval);
                _sr.enabled = false; // spriteRenderer���I�t

                yield return new WaitForSeconds(_flashInterval);
                _sr.enabled = true;
            }

            // �_�Ń��[�v���甲������
            _isHit = false;
        }
    }
}
