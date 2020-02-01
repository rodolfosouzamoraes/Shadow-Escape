using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlayer : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] JoyControl joyControl;

    Rigidbody2D myRigibody;
    BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;
    Animator myAnimator;
    PlayAudio playAudio;
    float gravityScaleAtStart;
    public bool isAlive;
    bool isLadder;
    bool isDirectionalLeft = false;
    bool isDirectionalRight = false;
    bool isDirectionalUp = false;
    bool isDirectionalDown = false;
    bool isDirectionalJump = false;
    int directionLadder = 1;


    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
        playAudio = GetComponent<PlayAudio>();
        gravityScaleAtStart = myRigibody.gravityScale;
    }
    void FixedUpdate()
    {
        if (!isAlive) { return; }

        //MovimentKeyboard();
        MovimentDirectionals();
    }

    private void MovimentKeyboard()
    {
        Jump();
        ClimpLadder();
        Run();
        
        
    }

    private void MovimentDirectionals()
    {
        ClimbLadder(joyControl.MovimentVertical());
        MovimentX(joyControl.MovimentHorizontal());

    }

    private void ClimbLadder(float value)
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigibody.gravityScale = 0;
            myRigibody.velocity = new Vector2(0, 0);
            LadderMoviments(value);
        }
        else
        {
            myRigibody.gravityScale = gravityScaleAtStart;
        }
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playAudio.Play(0);
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
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigibody.velocity.y);
        myRigibody.velocity = playerVelocity;
        Vector3 novoScale = new Vector3(controlThrow>0 ? 1 : controlThrow<0 ? -1 : transform.localScale.x, transform.localScale.y,1);
        transform.localScale = novoScale;
        GetComponent<FlipLifeBar>().FlipBarLife(novoScale);

        if(controlThrow != 0)
        {
            myAnimator.SetBool("run", true);
            myAnimator.SetBool("idle", false);
            myAnimator.SetBool("jump", false);
        }
        else
        {
            AnimationIdle();
        }
        
    }

    public void MovimentLeft()
    {
        isDirectionalLeft = true;
    }

    public void MovimentRight()
    {
        isDirectionalRight = true;
    }

    public void MovimentUp()
    {
        isDirectionalUp = true;
        directionLadder = 1;
    }

    public void MovimentDown()
    {
        isDirectionalDown= true;
        directionLadder= - 1;
    }

    public void MovimentJump()
    {
        if (!isAlive) { return; }
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        playAudio.Play(0);
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        myRigibody.velocity += jumpVelocityToAdd;
    }

    public void StopMovimentLadder()
    {
        isDirectionalUp = false;
        isDirectionalDown = false;
        AnimationIdle();
        LadderMoviments(0);
    }

    public void StopMoviments()
    {
        isDirectionalLeft = false;
        isDirectionalRight = false;
        isDirectionalUp = false;
        isDirectionalDown = false;
        AnimationIdle();
    }

    public void LadderMoviments(float contrlThrow)
    {
        Vector2 climbVelocity = new Vector2(myRigibody.velocity.x, contrlThrow * climbSpeed);
        myRigibody.velocity = climbVelocity;
        myRigibody.gravityScale = 0;
    }
}
