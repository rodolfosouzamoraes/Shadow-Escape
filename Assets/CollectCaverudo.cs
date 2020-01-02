using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCaverudo : MonoBehaviour
{
    [SerializeField] int totalCaverudos = 0;

    public void AddCaverudo()
    {
        totalCaverudos++;
    }

    public int GetTotalCaverudo()
    {
        return totalCaverudos;
    }
}
