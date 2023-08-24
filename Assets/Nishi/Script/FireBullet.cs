using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //‹Ê‚ð”­ŽË‚·‚é
        {
            transform.Translate (new Vector2(speed, 0f) * Time.deltaTime);
        }
    }
}
