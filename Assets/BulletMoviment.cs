using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoviment : MonoBehaviour
{
    float controlThrow;
    float runSpeed = 7;
    Rigidbody2D myRigibody;
    void Start()
    {
        myRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(controlThrow * runSpeed, myRigibody.velocity.y);
        myRigibody.velocity = velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.gameObject.GetComponent<CollisionPlayer>().DamagePlayer();
                Destroy(gameObject);
                break;
            case "Ground":
                Destroy(gameObject);
                break;
        }
    }

    public void ChangeControlTrow(float v)
    {
        controlThrow = v;
    }
}
