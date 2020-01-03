using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShadowArea : MonoBehaviour
{
    public bool isActived = false;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetType() == typeof(CapsuleCollider2D))
        {
            if (isActived)
            {
                collision.gameObject.GetComponent<CollisionPlayer>().KillPlayer();
            }
        }
        
        

    }
}
