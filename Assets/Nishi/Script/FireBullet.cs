using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _ri;
    SpriteRenderer player;
    private bool _SR;

    // Start is called before the first frame update
    private void OnEnable()
    {
        player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        _SR = player.flipX;
    }

    private void FixedUpdate()
    {
        if (_SR)
        {
            _ri.velocity = new Vector2(-20, 0);
        }
        else
        {
            _ri.velocity = new Vector2(20, 0);
        }
    }
}
