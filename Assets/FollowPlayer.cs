using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        transform.position = target.transform.position;
    }
}
