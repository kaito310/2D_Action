using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    private bool _SR;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        _SR = player.GetComponent<SpriteRenderer>().flipX;
        if (_SR)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        }
    }
}
