using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----������㉺�ɓ������X�N���v�g----
public class MoveY_axis : MonoBehaviour
{
    [SerializeField] float _length; // �����͈�
    float moveY; // y�������̒l

    // Update is called once per frame
    void Update()
    {
        // ���������l�����Ԃ���v�Z
        moveY = Mathf.PingPong(Time.time, _length);

        // y���W�����������ď㉺�ɓ�����
        transform.localPosition = new Vector2(transform.position.x, moveY);
    }
}
