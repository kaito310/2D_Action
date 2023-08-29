using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim = null;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
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
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        anim.SetBool("Jump", false);
        anim.Play("Hit");
        if (playerControllerScript.isDead == true)
        {
            anim.Play("Death");
        }
    }
}
