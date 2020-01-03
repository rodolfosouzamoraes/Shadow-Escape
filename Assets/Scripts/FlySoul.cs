using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySoul : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
