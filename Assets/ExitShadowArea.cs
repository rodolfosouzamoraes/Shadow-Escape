using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShadowArea : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player Death");
        collision.gameObject.GetComponent<CollisionPlayer>().KillPlayer();
    }
}
