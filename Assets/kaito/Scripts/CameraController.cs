using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�v���C���[�L������ǔ�����J�����̃X�N���v�g----
public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    Vector3 offset; // player�Ƃ̑��΋���

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player != null) // player�����݂���Ƃ�
        {
            transform.position = offset + _player.transform.position;
        }
    }
}
