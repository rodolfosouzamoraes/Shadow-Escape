using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    [SerializeField] int totalBattery = 0;

    public void AddBattery()
    {
        GetComponent<PlayAudio>().Play(3);
        totalBattery++;
    }

    public int GetTotalBattery()
    {
        return totalBattery;
    }
}
