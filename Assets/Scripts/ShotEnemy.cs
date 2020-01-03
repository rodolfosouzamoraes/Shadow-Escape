using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemy : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    public void InstanciateBullet()
    {
        GameObject go = Instantiate(bullet, transform.position + new Vector3(-0.94f* transform.localScale.x, 0.08f, 0), Quaternion.identity);
        BulletMoviment bm = go.GetComponent<BulletMoviment>();
        bm.ChangeControlTrow(transform.localScale.x*-1);
        Destroy(go, 1f);
    }
}
