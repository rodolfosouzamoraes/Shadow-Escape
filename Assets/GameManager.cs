using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3[] positionCamera;
    [SerializeField] Vector2[] positionShadowStage;
    [SerializeField] Vector2[] positionPlayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject shadow;
    [SerializeField] GameObject camera;
    [SerializeField] int stage;
    [SerializeField] float waySpeed = 2f;

    [SerializeField] Vector2[] wayStage1;

    bool isStartWay = false;
    int way = 0;
    
    void Start()
    {
        player.GetComponent<MovimentPlayer>().isAlive = false;
        stage = 0;
        Invoke("StartGame", 4.5f);
    }

    void StartGame()
    {
        player.transform.position = positionPlayer[0];
        shadow.transform.position = positionShadowStage[0];
        camera.transform.position = positionCamera[0];
        player.GetComponent<MovimentPlayer>().isAlive = true;
        shadow.GetComponent<ExitShadowArea>().isActived = true;
        Invoke("StartWay", 1f);

    }

    void StartWay()
    {
        isStartWay = true;
    }

    private void Update()
    {
        if (isStartWay)
        {

            //shadow.transform.position = wayStage1[way];
            shadow.transform.Translate(wayStage1[1] * Time.deltaTime * waySpeed,Space.Self);
        }
    }


}
