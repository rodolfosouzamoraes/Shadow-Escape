using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBoss : MonoBehaviour
{
    [SerializeField] int lives = 8;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject stage;
    private void Start()
    {
        princess.GetComponent<Rigidbody2D>().gravityScale = 0;
        lives = PlayerPrefs.GetInt("CaverudosDeath") - PlayerPrefs.GetInt("TotalCaverudos") + 4;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            lives--;
            Debug.Log(lives);
            collision.gameObject.GetComponent<CollisionPlayer>().SoftLeapPlayer();
            if (lives <= 0)
            {
                GetComponent<PlayAudio>().Play(1);
                GetComponent<Animator>().SetBool("Boss", false);
                GetComponent<Animator>().SetBool("Death", true);
                FindObjectOfType<ManageTheEnd>().Finish();
                Destroy(GetComponent<BoxCollider2D>());

            }
            else
            {
                GetComponent<PlayAudio>().Play(0);
            }

        }
        else if (collision.collider.GetType() == typeof(CapsuleCollider2D))
        {
            collision.gameObject.GetComponent<CollisionPlayer>().DamagePlayer(3);
        }
    }

    void FreePrincess()
    {
        princess.transform.SetParent(stage.transform);
        princess.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
