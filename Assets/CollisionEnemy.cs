using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    [SerializeField] GameObject soul;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(BoxCollider2D))
        {
            switch (collision.gameObject.tag)
            {
                case "Player":
                    collision.gameObject.GetComponent<CollisionPlayer>().SoftLeapPlayer();
                    Instantiate(soul, transform.position + new Vector3(0.4f * transform.localScale.x, 0.42f, 0), Quaternion.identity);
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
