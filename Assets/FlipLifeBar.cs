using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipLifeBar : MonoBehaviour
{
    [SerializeField] Transform transformBarLife;
    public void FlipBarLife(float factor)
    {
        transformBarLife.localScale = new Vector3(factor, 1, 1);
    }
}
