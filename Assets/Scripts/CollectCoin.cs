using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] public Vector3 checkpoint;
    [SerializeField] public bool isCheckPoint;
    [SerializeField] public int wayPoint;
    public void CheckPoint()
    {
        GetComponent<PlayAudio>().Play(5);
        checkpoint = transform.position;
        isCheckPoint = true;
        wayPoint = FindObjectOfType<GameManager>().way;
    }
}
