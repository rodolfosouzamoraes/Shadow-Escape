﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBoss : MonoBehaviour
{
    [SerializeField] int lives = 8;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject stage;

    Vector2 positionDeath;
    private void Start()
    {
        princess.GetComponent<Rigidbody2D>().gravityScale = 0;
        lives = PlayerPrefs.GetInt("CaverudosDeath") - PlayerPrefs.GetInt("TotalCaverudos");
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
                FindObjectOfType<ManageTheEnd>().DestroyShadow();
                GetComponent<Animator>().SetBool("Boss", false);
                GetComponent<Animator>().SetBool("Death", true);
                Destroy(GetComponent<BoxCollider2D>());

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
