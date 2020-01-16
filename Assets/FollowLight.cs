using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float waySpeed = 2f;
    public bool isFollow = false;
    public float sizeCamera8px = 4f;
    float sizeCameraOri;
    Camera camera;
    Vector3 lastPositionTarget;
    bool isNextWay = false;
    Vector3 move;

    private void Start()
    {
        camera = GetComponent<Camera>();
        sizeCameraOri = camera.orthographicSize;
    }

    private void Update()
    {
        if (isFollow)
        {
            camera.orthographicSize = sizeCamera8px;
            if (Vector3.Distance(move, camera.transform.position) <= 0)
            {
                move = new Vector3(PixelPerfectClamp(target.transform.position, 8).x, PixelPerfectClamp(target.transform.position, 8).y, -5);
            }
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, move, Time.fixedDeltaTime * waySpeed);
        }
        else
        {
            camera.orthographicSize = sizeCameraOri;
            lastPositionTarget = target.transform.position;
            isNextWay = false;
        }
        
    }

    public void MoveCameraForPositionTheLight() 
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        move = new Vector3(PixelPerfectClamp(target.transform.position, 8).x, PixelPerfectClamp(target.transform.position, 8).y, -5);
    }
    
    private Vector2 PixelPerfectClamp(Vector2 moveVector, float pixelPerUnity)
    {
        Vector2 vectorInPixels = new Vector2(
            Mathf.RoundToInt(moveVector.x * pixelPerUnity),
            Mathf.RoundToInt(moveVector.y * pixelPerUnity)
            );
        return vectorInPixels / pixelPerUnity;
    }
}
