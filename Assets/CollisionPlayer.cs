using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] SpriteRenderer barLife;
    [SerializeField] Sprite[] barlives;

    int totalLife;
    public int totalDamage;
    public bool isFinishStage;
    float damageForce = 25f;
    Rigidbody2D myRigibody;
    Animator myAnimator;
    MovimentPlayer movimentPlayer;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movimentPlayer = GetComponent<MovimentPlayer>();
        totalLife = barlives.Length;
        totalDamage = 0;
        isFinishStage = false;
    }

    public void SoftLeapPlayer()
    {
        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
        myRigibody.velocity += jumpVelocityToAdd;
    }

    public void DamagePlayer()
    {
        if (movimentPlayer.isAlive)
        {
            totalDamage++;
            if (totalDamage < totalLife)
            {
                barLife.sprite = barlives[totalDamage];
            }
            if (totalDamage >= totalLife-1)
            {
                KillPlayer();
            }
            myRigibody.velocity = new Vector2(2f * transform.localScale.x * -1, 2f);
        }
    }

    public void KillPlayer()
    {
        myAnimator.SetBool("death", true);
        movimentPlayer.isAlive = false;
        myRigibody.velocity = new Vector2(damageForce * transform.localScale.x*-1, damageForce);
        Invoke("ReloadLevel", 1.5f);
    }

    public void RestoreLife()
    {
        totalDamage = 0;
        barLife.sprite = barlives[totalDamage];
    }

    void ReloadLevel()
    {
        RestoreLife();
        GameManager gm = FindObjectOfType<GameManager>();
        myRigibody.velocity = new Vector2(0,0);
        myAnimator.SetBool("idle", true);
        myAnimator.SetBool("run", false);
        myAnimator.SetBool("jump", false);
        myAnimator.SetBool("death", false);

        gm.ResetStage();

    }


}
