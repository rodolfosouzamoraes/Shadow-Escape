using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] float damageForce = 30f;

    Rigidbody2D myRigibody;
    BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;
    Animator myAnimator;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    public void SoftLeapPlayer()
    {
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        myRigibody.velocity += jumpVelocityToAdd;
    }

    public void DamagePlayer()
    {
        //Tirar Vida
        myRigibody.velocity = new Vector2(2f * transform.localScale.x * -1, 2f);
    }

    public void KillPlayer()
    {
        myAnimator.SetBool("death", true);
        GetComponent<MovimentPlayer>().isAlive = false;
        myRigibody.velocity = new Vector2(25f * transform.localScale.x*-1, 25f);
    }


}
