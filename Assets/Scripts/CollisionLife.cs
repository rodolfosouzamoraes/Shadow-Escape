using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag.Equals("Player"))
        {
            CollisionPlayer cp = collision.gameObject.GetComponent<CollisionPlayer>();
            if (cp.totalDamage > 0)
            {
                cp.RestoreLife();
                Destroy(gameObject);
            }
            
            
        }
    }
}
