using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlayer : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D myRigibody;
    BoxCollider2D myBoxCollider;
    Animator myAnimator;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        Run();
        Jump();
    }

    private void Jump()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigibody.velocity += jumpVelocityToAdd;
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MovimentX(1);
        }else if (Input.GetKey(KeyCode.A))
        {
            MovimentX(-1);
        }
        else
        {
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
                myAnimator.SetBool("run", false);
                myAnimator.SetBool("idle", true);
                myAnimator.SetBool("jump", false);
            }
            else
            {
                myAnimator.SetBool("idle", false);
                myAnimator.SetBool("jump", true);
            }
            
        }
    }

    private void MovimentX(float controlThrow)
    {
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigibody.velocity.y);
        myRigibody.velocity = playerVelocity;
        Vector2 novoScale = new Vector2(controlThrow, transform.localScale.y);
        transform.localScale = novoScale;


        myAnimator.SetBool("run", true);
        myAnimator.SetBool("idle", false);
        myAnimator.SetBool("jump", false);
    }
}
