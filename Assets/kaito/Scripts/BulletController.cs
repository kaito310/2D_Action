using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�G���甭�˂����e�̃X�N���v�g----
/* �E�e�̌��݈ʒu�i�ړ����̈ʒu�j�ɐ�������Ă��܂�
   �E�j��ł��Ă��Ȃ� */
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // ���x
    [SerializeField] GameObject parentEnemy;
    [SerializeField] GameObject bulletPrefab;
    
    float elapsedTime; // �o�ߎ���
    [SerializeField] float timeBounds; // ���ԏ��
    [SerializeField] float deleteTime; // �j��܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0f) * Time.deltaTime);
        Shooting();
    }

    void Shooting() // �G���e�𔭎˂���֐�
    {
        elapsedTime += Time.deltaTime; // ��F�̎��Ԃ𑫂��Ă���

        // �e�I�u�W�F�N�g�����݂���Ƃ��A���o�ߎ��Ԃ����ԏ���i�b�j���z������
        if (parentEnemy && elapsedTime > timeBounds)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation); // �e�𐶐�

            elapsedTime = 0; // �o�ߎ��ԃ��Z�b�g
        }

        if (elapsedTime == deleteTime) // �o�ߎ��Ԃ��j�󎞊Ԃ��z������
        {
            Debug.Log("a");
            Destroy(gameObject);
        }
    }
}
