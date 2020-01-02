using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBoss : MonoBehaviour
{
    [SerializeField] int lives = 8;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            lives--;
            Debug.Log(lives);
            collision.gameObject.GetComponent<CollisionPlayer>().SoftLeapPlayer();
            if (lives <= 0)
            {
                Destroy(gameObject);
                //End Game
                //BossDeath
            }
        }
        else if (collision.collider.GetType() == typeof(CapsuleCollider2D))
        {
            collision.gameObject.GetComponent<CollisionPlayer>().DamageBossPlayer();
        }
        
    }
}
