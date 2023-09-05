using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�G���甭�˂����e�̃X�N���v�g----
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // ���x
    [SerializeField] float _deleteTime; // �j��܂ł̎���

    void Start()
    {
        Destroy(gameObject, _deleteTime); // _deleteTime(�b)�ō폜
    }

    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �v���C���[���X�e�[�W�ɓ������������
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Stage"))
        {
            Destroy(gameObject);
        }
    }
}
