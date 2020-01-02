using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    [SerializeField] GameObject shot;

    public void Shot()
    {
        GameObject shot1 = Instantiate(shot, transform.position + new Vector3(-8.89f, 7f, 0), Quaternion.identity);//0.86
        SetMovimentShot(shot1);
        GameObject shot2 = Instantiate(shot, transform.position + new Vector3(-8.89f, 3.35f, 0), Quaternion.identity);
        SetMovimentShot(shot2);
        GameObject shot3 = Instantiate(shot, transform.position + new Vector3(-8.89f, -0.69f, 0), Quaternion.identity);
        SetMovimentShot(shot3);
        GameObject shot4 = Instantiate(shot, transform.position + new Vector3(-8.89f, -4.63f, 0), Quaternion.identity);
        SetMovimentShot(shot4);
        GameObject shot5 = Instantiate(shot, transform.position + new Vector3(-8.89f, -2.599f, 0), Quaternion.identity);
        SetMovimentShot(shot5);
        GameObject shot6 = Instantiate(shot, transform.position + new Vector3(-8.89f, 1.43f, 0), Quaternion.identity);
        SetMovimentShot(shot6);
        GameObject shot7 = Instantiate(shot, transform.position + new Vector3(-8.89f, 5.34f, 0), Quaternion.identity);
        SetMovimentShot(shot7);
        GameObject shot8 = Instantiate(shot, transform.position + new Vector3(-8.89f, -6.42f, 0), Quaternion.identity);
        SetMovimentShot(shot8);
    }

    private static void SetMovimentShot(GameObject shot1)
    {
        shot1.transform.localScale = new Vector2(2.7f, 2.7f);
        BulletMoviment bm = shot1.GetComponent<BulletMoviment>();
        bm.ChangeControlTrow(-1);
    }
}
