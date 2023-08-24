using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim = null;
    private int HitCheck;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-3, 3, 3);
            anim.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(3, 3, 3);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
        }
     }
    private void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.CompareTag("floor"))
        {
            anim.SetBool("Jump", false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            HitCheck++;
            anim.Play("Hit");
            if (HitCheck > 3)
            {
                anim.SetFloat("Death");
            }
        }
    }
}
