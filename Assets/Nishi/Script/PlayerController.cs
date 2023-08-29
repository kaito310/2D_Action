using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jump = 1;
    [SerializeField] GameObject bullet;
    private Rigidbody2D _rd2D;
    private bool isjump = false;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public int HitCheck;

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
        if (Input.GetKeyDown(KeyCode.W)) //‹Ê‚ð”­ŽË‚·‚é
        {
            GameObject _Bullet = Instantiate(bullet) as GameObject;
            _Bullet.transform.position = this.transform.position;
            Destroy(_Bullet, 0.8f);
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
            Debug.Log("“G‚ÆÚG‚µ‚½I");
            HitCheck++;
        }
         if (isDead == false)
        {
            if (HitCheck > 2)
            {
                isDead = true;
            }
        }
    }
}