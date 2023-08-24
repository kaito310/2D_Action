using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----敵が壁に衝突時にバウンドさせるスクリプト----
public class SphereMover : MonoBehaviour
{
    [SerializeField] float _speed; // 速度

    Vector2 startPos;
    Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Bound();
    }

    void Bound()
    {
        pos = transform.position;
    }
}
