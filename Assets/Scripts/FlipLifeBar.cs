using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipLifeBar : MonoBehaviour
{
    [SerializeField] Transform transformBarLife;
    public void FlipBarLife(Vector3 factor)
    {
        transformBarLife.localScale = new Vector3(factor.x, factor.y, 1);
    }
}
