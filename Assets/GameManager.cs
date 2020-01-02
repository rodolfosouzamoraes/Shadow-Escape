using System;
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
    [SerializeField] Vector2[] wayStage2;
    [SerializeField] Vector2[] wayStage3;
    [SerializeField] Vector2[] wayStage4;
    [SerializeField] Vector2[] wayStage5;

    bool isStartWay = false;
    int way = 0;
    MovimentPlayer movimentPlayer;
    
    void Start()
    {
        movimentPlayer = player.GetComponent<MovimentPlayer>();
        movimentPlayer.isAlive = false;
        stage = 0;
        Invoke("StartGame", 4.5f);
    }

    void StartGame()
    {
        player.transform.position = positionPlayer[0];
        shadow.transform.position = positionShadowStage[0];
        camera.transform.position = positionCamera[0];
        movimentPlayer.isAlive = true;
        shadow.GetComponent<ExitShadowArea>().isActived = true;
        Invoke("StartWay", 1f);

    }

    void StartWay()
    {
        isStartWay = true;
    }

    public void PauseWay()
    {
        isStartWay = false;
    }

    private void Update()
    {
        if (movimentPlayer.isAlive)
        {
            if (isStartWay)
            {
                switch (stage)
                {
                    case 0:
                        WayPoint(wayStage1);
                        break;
                    case 1:
                        WayPoint(wayStage2);
                        break;
                    case 2:
                        WayPoint(wayStage3);
                        break;
                    case 3:
                        WayPoint(wayStage3);
                        break;
                    case 4:
                        WayPoint(wayStage4);
                        break;
                    case 5:
                        WayPoint(wayStage5);
                        break;
                }
                
            }
        }
        
    }

    private void WayPoint(Vector2[] wayStage)
    {
        if (Vector3.Distance(wayStage[way], shadow.transform.position) < 1)
        {
            way++;
            if (way >= wayStage.Length)
            {
                way = 0;
                PauseWay();
                if (player.GetComponent<CollisionPlayer>().isFinishStage)
                {
                    //Next Stage
                    stage++;
                    player.GetComponent<CollisionPlayer>().isFinishStage = false;
                    shadow.GetComponent<ExitShadowArea>().isActived = false;
                    movimentPlayer.isAlive = false;
                    player.transform.position = positionPlayer[stage + 1];
                    shadow.transform.position = positionShadowStage[stage + 1];
                    camera.transform.position = positionCamera[stage + 1];
                    shadow.GetComponent<Animator>().Play("Shadow", -1, 0);
                    Invoke("NextStage", 4.5f);
                }
                return;
            }
        }
        shadow.transform.position = Vector3.MoveTowards(shadow.transform.position, wayStage[way], Time.deltaTime * waySpeed);
    }

    public void ResetStage()
    {
        way = 0;
        player.transform.position = positionPlayer[stage];
        shadow.transform.position = positionShadowStage[stage];
        camera.transform.position = positionCamera[stage];
        Invoke("EnablePlayer", 1f);
    }

    void EnablePlayer()
    {
        movimentPlayer.isAlive = true;
    }

    void NextStage()
    {
        shadow.GetComponent<ExitShadowArea>().isActived = true;
        movimentPlayer.isAlive = true;
        StartWay();
        player.transform.position = positionPlayer[stage];
        shadow.transform.position = positionShadowStage[stage];
        camera.transform.position = positionCamera[stage];
    }


}
