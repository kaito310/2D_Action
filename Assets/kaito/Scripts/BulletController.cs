using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----�G���甭�˂����e�̃X�N���v�g----
public class BulletController : MonoBehaviour
{
    [SerializeField] float _velocity; // ���x

    [HideInInspector] public Vector2 _startPos; // �����ʒu

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_velocity, 0f) * Time.deltaTime);
    }
}
