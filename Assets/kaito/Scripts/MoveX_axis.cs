using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----��������E�ɓ������X�N���v�g----
public class MoveX_axis : MonoBehaviour
{
    [SerializeField] float _length; // �����͈�
    float moveX; // x�������̒l

    // Update is called once per frame
    void Update()
    {
        // ���������l�����Ԃ���v�Z
        moveX = Mathf.PingPong(Time.time, _length);

        // x���W�����������č��E�ɓ�����
        transform.localPosition = new Vector2(moveX, transform.position.y);
    }
}
