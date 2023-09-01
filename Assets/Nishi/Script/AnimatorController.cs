using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim = null;
    private PlayerController playerControllerScript;
    private float oldPositionY = 0f;
    private JumpState jumpState = JumpState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isDead == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("Run", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
        if (jumpState == JumpState.Jumping)
        {
            anim.SetBool("Jump", true);
        }
        if (jumpState == JumpState.Falling)
        {
            anim.SetBool("Fall", true);
        }
        if (jumpState == JumpState.Idle)
        {
            anim.SetBool("Fall", false);
            anim.SetBool("Jump", false);
        }
        if (playerControllerScript.isGun == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("Attack", true);
            }
            else
            {
                anim.SetBool("Attack", false);
            }
        }
        if (playerControllerScript.isjump == false)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
        if (playerControllerScript.isHit == true && playerControllerScript.isDead == false)
        {
            anim.SetBool("Hit", true);
        }
        else
        {
            anim.SetBool("Hit", false);
        }
        if (playerControllerScript.isDead == true)
        {
            playerControllerScript.isHit = false;
            anim.Play("Death");
        }
    }

    private enum JumpState
    {
        Idle,
        Jumping,
        Falling
    }

    private void FixedUpdate()
    {
        CheckJumpState();
    }

    private void CheckJumpState()
    {
        if (oldPositionY < this.transform.position.y)
        {
            jumpState = JumpState.Jumping;

        }
        else if (oldPositionY > this.transform.position.y)  
        {
            jumpState = JumpState.Falling;
        }
        else 
        {
            jumpState = JumpState.Idle;
        }
        oldPositionY = this.transform.position.y;
    }
}
