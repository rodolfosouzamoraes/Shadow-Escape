using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPrincess : MonoBehaviour
{
    [SerializeField] GameObject theEnd;
    // Start is called before the first frame update
    void Start()
    {
        theEnd.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetInt("Stage",0);
            collision.gameObject.GetComponent<MovimentPlayer>().isAlive = false;
            collision.gameObject.GetComponent<MovimentPlayer>().AnimationIdle();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetBool("Finish", true);
            theEnd.SetActive(true);
        }
    }
}
