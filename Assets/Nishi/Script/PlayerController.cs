using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jump = 1;
    private Rigidbody2D _rd2D;
    private int jumpCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _rd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
           position.x -= speed * Time.deltaTime;
           if (Input.GetKey(KeyCode.D))
            {
                position.x += speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                position.x -= speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _rd2D.AddForce(transform.up * jump);
            jumpCount++;
        }

        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            jumpCount = 0;
        }
    }
}
