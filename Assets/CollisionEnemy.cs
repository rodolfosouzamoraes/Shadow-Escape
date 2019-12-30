using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    collision.gameObject.GetComponent<CollisionPlayer>().SoftLeapPlayer();
                    Destroy(gameObject);
                    break;
            }
        }
        else if (collision.collider.GetType() == typeof(CapsuleCollider2D))
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    collision.gameObject.GetComponent<CollisionPlayer>().KillPlayer();
                    break;
            }
        }

    }
}
