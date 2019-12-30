using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlayer : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D myRigibody;
    BoxCollider2D myBoxCollider;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Run();
        Jump();
    }

    private void Jump()
    {
        if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
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
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovimentX(-1);
        }
    }

    private void MovimentX(float controlThrow)
    {
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigibody.velocity.y);
        myRigibody.velocity = playerVelocity;

        //bool playerHasHorizontalSpeed = Mathf.Abs(myRigibody.velocity.x) > Mathf.Epsilon;
        //myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }
}
