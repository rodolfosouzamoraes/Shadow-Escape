using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    PlayAudio playAudio;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movimentPlayer = GetComponent<MovimentPlayer>();
        playAudio = GetComponent<PlayAudio>();
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
                playAudio.Play(1);
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
        playAudio.Play(2);
        barLife.sprite = barlives[barlives.Length-1];
        myAnimator.SetBool("death", true);
        movimentPlayer.isAlive = false;
        myRigibody.velocity = new Vector2(damageForce * transform.localScale.x*-1, damageForce);
        Invoke("ReloadLevel", 1.5f);
    }

    public void KillPlayer(bool v)
    {
        playAudio.Play(2);
        barLife.sprite = barlives[barlives.Length - 1];
        myAnimator.SetBool("death", v);
        movimentPlayer.isAlive = false;
        myRigibody.velocity = new Vector2(damageForce * transform.localScale.x * -1, damageForce);
        Invoke("ResetStage", 1.5f);
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

    void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DamagePlayer(int value)
    {
        if (movimentPlayer.isAlive)
        {
            totalDamage+= value;
            if (totalDamage < totalLife)
            {
                playAudio.Play(1);
                barLife.sprite = barlives[totalDamage];
            }
            if (totalDamage >= totalLife - 1)
            {
                barLife.sprite = barlives[barlives.Length-1];
                KillPlayer(true);
            }
            else
            {
                myRigibody.velocity = new Vector2(damageForce * transform.localScale.x * -1, damageForce);
            }
           
        }
    }


}
