﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] int totalCoins = 0;
    
    public void AddCoin()
    {
        totalCoins++;
    }
}