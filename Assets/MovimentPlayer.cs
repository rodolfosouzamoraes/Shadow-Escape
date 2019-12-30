using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlayer : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    Rigidbody2D myRigibody;
    BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;
    Animator myAnimator;
    float gravityScaleAtStart;
    public bool isAlive { get; set; }
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
        gravityScaleAtStart = myRigibody.gravityScale;
        isAlive = true;
    }
    void Update()
    {
        if (!isAlive) { return; }

        Run();
        ClimpLadder();
        Jump();
        
    }

    private void ClimpLadder()
    {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            //myAnimator.SetBool("Climbing", false);
            myRigibody.gravityScale = gravityScaleAtStart;
            return;
        }
        Debug.Log("Encostou na escada!");

        if (Input.GetKey(KeyCode.W))
        {
            MovimentY(1);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            MovimentY(-1);
        }
        else
        {
            myRigibody.velocity = new Vector2(myRigibody.velocity.x, 0);
        }

    }

    private void MovimentY(int controlThrow)
    {
        Vector2 climbVelocity = new Vector2(myRigibody.velocity.x, controlThrow * climbSpeed);
        myRigibody.velocity = climbVelocity;
        myRigibody.gravityScale = 0;
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
