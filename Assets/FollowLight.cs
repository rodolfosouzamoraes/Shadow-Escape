using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    [SerializeField] GameObject target;
    public bool isFollow = false;

    private void Update()
    {
        if (isFollow)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
        
    }
}
