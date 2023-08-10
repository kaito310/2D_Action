using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----プレイヤーキャラを追尾するカメラのスクリプト----
public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    Vector3 offset; // playerとの相対距離

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player != null) // playerが存在するとき
        {
            transform.position = offset + _player.transform.position;
        }
    }
}
