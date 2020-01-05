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
    PlayAudio playAudio;
    float gravityScaleAtStart;
    public bool isAlive;
    bool isLadder;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
        playAudio = GetComponent<PlayAudio>();
        gravityScaleAtStart = myRigibody.gravityScale;
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
            isLadder = false;
            myRigibody.gravityScale = gravityScaleAtStart;  
        }
        else
        {
            if (!isLadder)
            {
                isLadder = true;
                myRigibody.velocity = new Vector2(0, 0);
                myRigibody.gravityScale = 0;
            }
            float contrlThrow = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myRigibody.velocity.x, contrlThrow * climbSpeed);
            myRigibody.velocity = climbVelocity;
            myRigibody.gravityScale = 0;
        }

        

    }


    private void Jump()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        float jump = Input.GetAxis("Jump");

        if (jump!=0)
        {
            playAudio.Play(0);
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigibody.velocity = jumpVelocityToAdd;
        }
    }

    private void Run()
    {
        float movimentX = Input.GetAxis("Horizontal");

        if (movimentX != 0)
        {
            MovimentX(movimentX);
        }
        else
        {
            myRigibody.velocity = new Vector2(0, myRigibody.velocity.y);
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                AnimationIdle();
            }
            else
            {
                myAnimator.SetBool("idle", false);
                myAnimator.SetBool("jump", true);
            }
        }
    }

    public void AnimationIdle()
    {
        myAnimator.SetBool("run", false);
        myAnimator.SetBool("idle", true);
        myAnimator.SetBool("jump", false);
    }

    private void MovimentX(float controlThrow)
    {
        //if (controlThrow > 0)
        //{
        //    controlThrow = 1;
        //}
        //else if (controlThrow < 0)
        //{
        //    controlThrow = -1;
        //}
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigibody.velocity.y);
        myRigibody.velocity = playerVelocity;
        Vector3 novoScale = new Vector3(controlThrow, transform.localScale.y,1);
        transform.localScale = novoScale;
        GetComponent<FlipLifeBar>().FlipBarLife(controlThrow);


        myAnimator.SetBool("run", true);
        myAnimator.SetBool("idle", false);
        myAnimator.SetBool("jump", false);
    }
}
