using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3[] positionCamera;
    [SerializeField] Vector2[] positionShadowStage;
    [SerializeField] Vector2[] positionPlayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject light;
    [SerializeField] GameObject camera;
    [SerializeField] int stage;
    [SerializeField] float waySpeed = 2f;
    [SerializeField] int totalBatteryInGame;
    [SerializeField] int totalCaverudo;
    [SerializeField] GameObject canvasDirecional;

    [SerializeField] Vector2[] wayStage1;
    [SerializeField] Vector2[] wayStage2;
    [SerializeField] Vector2[] wayStage3;
    [SerializeField] Vector2[] wayStage4;
    [SerializeField] Vector2[] wayStage5;

    bool isStartWay = false;
    public int way = 0;
    MovimentPlayer movimentPlayer;
    FollowLight cameraFollowLight;
    
    void Start()
    {
        //Cursor.visible = false;
        totalBatteryInGame = GameObject.FindGameObjectsWithTag("Battery").Length;
        totalCaverudo = GameObject.FindGameObjectsWithTag("Enemy").Length;
        PlayerPrefs.SetInt("TotalCaverudos", totalCaverudo);
        PlayerPrefs.SetInt("TotalBattery", totalBatteryInGame);
        PlayerPrefs.SetInt("TotalBatteryCollected", 0);
        PlayerPrefs.SetInt("CaverudosDeath", 0);

        cameraFollowLight = camera.GetComponent<FollowLight>();
        movimentPlayer = player.GetComponent<MovimentPlayer>();
        movimentPlayer.isAlive = false;
        stage = 0;
        Invoke("StartGame", 4.5f);
    }

    void StartGame()
    {
        canvasDirecional.SetActive(true);
        player.transform.position = positionPlayer[0];
        light.transform.position =  new Vector3(positionShadowStage[0].x, positionShadowStage[0].y, -5.83f);
        cameraFollowLight.MoveCameraForPositionTheLight();
        cameraFollowLight.isFollow = true;
        movimentPlayer.isAlive = true;
        light.GetComponent<ExitShadowArea>().isActived = true;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

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
                        WayPoint(wayStage4);
                        break;
                    case 4:
                        WayPoint(wayStage5);
                        break;
                }

            }
        }

        NextLevel();
    }

    private void WayPoint(Vector2[] wayStage)
    {
       
        if (Vector3.Distance(new Vector3(wayStage[way].x, wayStage[way].y,-5.83f), light.transform.position) <= 0)
        {
            way++;
            if (way >= wayStage.Length)
            {
                way = 0;
                PauseWay();
                return;
            }
        }
        light.transform.position = Vector3.MoveTowards(light.transform.position, new Vector3(wayStage[way].x, wayStage[way].y, -5.83f), Time.fixedDeltaTime * waySpeed);
    }

    public void NextLevel()
    {
        if(player.GetComponent<CollisionPlayer>().isFinishStage && !isStartWay)
        {
            stage++;
            if (stage > 4)
            {
                //Scene Final
                PlayerPrefs.SetInt("TotalBatteryCollected", player.GetComponent<CollectBattery>().GetTotalBattery());
                PlayerPrefs.SetInt("CaverudosDeath", player.GetComponent<CollectCaverudo>().GetTotalCaverudo());
                SceneManager.LoadScene(2);
            }
            else
            {
                player.GetComponent<CollisionPlayer>().isFinishStage = false;
                light.GetComponent<ExitShadowArea>().isActived = false;
                movimentPlayer.isAlive = false;
                movimentPlayer.AnimationIdle();
                cameraFollowLight.MoveCameraForPositionTheLight();
                cameraFollowLight.isFollow = false;
                if (stage > 3)
                {
                    player.transform.position = positionPlayer[0];
                    light.transform.position = new Vector3(positionShadowStage[0].x, positionShadowStage[0].y, -5.83f);
                    camera.transform.position = positionCamera[0];
                }
                else
                {
                    player.transform.position = positionPlayer[stage + 1];
                    light.transform.position = new Vector3(positionShadowStage[stage + 1].x, positionShadowStage[stage + 1].y, -5.83f);
                    camera.transform.position = positionCamera[stage + 1];
                }
                canvasDirecional.SetActive(false);
                light.GetComponent<Animator>().Play("Light", -1, 0);
                Invoke("NextStage", 4.5f);


            }

        }
    }

    public void ResetStage(Vector3 checkpoint, bool isCheckpoint, int wayPoint)
    {
        if (!isCheckpoint)
        {
            way = 0;
            player.transform.position = positionPlayer[stage];
            light.transform.position = positionShadowStage[stage];
            cameraFollowLight.MoveCameraForPositionTheLight();

        }
        else
        {
            way = wayPoint;
            switch (stage)
            {
                case 0:
                    light.transform.position = wayStage1[wayPoint];
                    player.transform.position = new Vector3(wayStage1[wayPoint].x, wayStage1[wayPoint].y, checkpoint.z);
                    break;
                case 1:
                    light.transform.position = wayStage2[wayPoint];
                    player.transform.position = new Vector3(wayStage2[wayPoint].x, wayStage2[wayPoint].y, checkpoint.z);
                    break;
                case 2:
                    light.transform.position = wayStage3[wayPoint];
                    player.transform.position = new Vector3(wayStage3[wayPoint].x, wayStage3[wayPoint].y, checkpoint.z);
                    break;
                case 3:
                    light.transform.position = wayStage4[wayPoint];
                    player.transform.position = new Vector3(wayStage4[wayPoint].x, wayStage4[wayPoint].y, checkpoint.z);
                    break;
                case 4:
                    light.transform.position = wayStage5[wayPoint];
                    player.transform.position = new Vector3(wayStage5[wayPoint].x, wayStage5[wayPoint].y, checkpoint.z);
                    break;
            }
            cameraFollowLight.MoveCameraForPositionTheLight();
        }
        Invoke("EnablePlayer", 1f);

    }

    void EnablePlayer()
    {
        movimentPlayer.isAlive = true;
    }

    void NextStage()
    {
        CollectCoin cc = player.GetComponent<CollectCoin>();
        cc.checkpoint = new Vector3(0, 0, 0);
        cc.isCheckPoint = false;
        cc.wayPoint = 0;

        canvasDirecional.SetActive(true);
        light.GetComponent<ExitShadowArea>().isActived = true;
        movimentPlayer.isAlive = true;
        StartWay();
        player.transform.position = positionPlayer[stage];
        light.transform.position = new Vector3(positionShadowStage[stage].x, positionShadowStage[stage].y, -5.83f);
        cameraFollowLight.MoveCameraForPositionTheLight();
        cameraFollowLight.isFollow = true;
        //camera.transform.position = positionCamera[stage];
    }


}
