using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayShadow : MonoBehaviour
{
    [SerializeField] Vector2[] wayStage1;
    [SerializeField] GameObject shadow;
    [SerializeField] float waySpeed = 2f;
    public bool isStartWay = false;
    int way = 0;
    private void Update()
    {
        if (isStartWay)
        {

            //shadow.transform.position = wayStage1[way];
            shadow.transform.Translate(wayStage1[1] * Time.deltaTime * waySpeed, Space.World);
        }
    }
}
