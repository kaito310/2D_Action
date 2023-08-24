using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jump = 1;
    private Rigidbody2D _rd2D;
    private bool isjump = false;
    private int Player;
    
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
        if (Input.GetKey(KeyCode.Space) && !isjump)
        {
            _rd2D.velocity = Vector2.up * jump;
            isjump = true;
        }
        if (Input.GetKeyDown(KeyCode.W)) //ã Çî≠éÀÇ∑ÇÈ
        {

        }

            transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            isjump = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ìGÇ∆ê⁄êGÇµÇΩÅI");
        }
    }
}
