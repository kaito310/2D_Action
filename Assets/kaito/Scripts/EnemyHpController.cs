using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---�G���󂯂�_���[�W�����̃X�N���v�g---
public class EnemyHpController : MonoBehaviour
{
    [SerializeField] int _hp;
    bool _isHit = false; // �U�����󂯂���
    [HideInInspector] bool _isDead = false; // ���Ŕ���

    [SerializeField] float _flashInterval;// �_�ŊԊu
    [SerializeField] int _loopCount; // �_�Ŏ��̃��[�v�J�E���g
    SpriteRenderer _sr; // �_�ł����邽�߂�SpriteRenderer
    BoxCollider2D _bc2d; // �R���C�_�[�̃I���E�I�t��؂�ւ��邽�߂̕ϐ�
    Material _color; // �I�u�W�F�N�g�ɕt�^���Ă���F

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bc2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (_hp == 0) // HP��0�ɂȂ�����
        {
            Destroy(gameObject);
            _isDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �U�����󂯂Ă��邩�A���ł����炱��ȍ~�̏������s��Ȃ�
        if (_isHit || _isDead)
        {
            return;
        }

        // �v���C���[�̒e�����̔���ɓ���������
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _hp--;
            _isHit = true;
        }

        // �R���[�`���J�n
        StartCoroutine(Damage());
        Debug.Log("�R���[�`���J�n");
    }

    // �_�ł����鏈��
    IEnumerator Damage()
    {
        _sr.color = Color.black; // �F�����ɂ���

        // �_�Ń��[�v�J�n
        for (int i = 0; i < _loopCount; i++)
        {
            // _flashInterval(�b)�҂��Ă���
            yield return new WaitForSeconds(_flashInterval);
            _sr.enabled = false; // spriteRenderer���I�t

            yield return new WaitForSeconds(_flashInterval);
            _sr.enabled = true;
        }

        //---(�F�����ɖ߂�)---

        // �_�Ń��[�v���甲������
        _isHit = false;
    }
}
