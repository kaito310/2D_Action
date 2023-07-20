using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset; // player‚Æ‚Ì‘Š‘Î‹——£

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null) // player‚ª‘¶İ‚·‚é‚Æ‚«
        {
            transform.position = offset + player.transform.position;
        }
    }
}
