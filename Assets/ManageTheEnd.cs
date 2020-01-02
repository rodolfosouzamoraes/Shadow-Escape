using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ManageTheEnd : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;
    [SerializeField] Light light;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("TotalBattery",16);
        PlayerPrefs.SetInt("TotalBatteryCollected",16);

        Invoke("StartStage", 3f);
        int totalBattery = PlayerPrefs.GetInt("TotalBattery");
        int totalBatteryCollected = PlayerPrefs.GetInt("TotalBatteryCollected");
        float difTotalBattery = (116f/totalBattery)* totalBatteryCollected;
        light.spotAngle += difTotalBattery;
    }

    private void StartStage()
    {
        player.GetComponent<MovimentPlayer>().isAlive = true;
        boss.GetComponent<Animator>().SetBool("Boss", true);
        

    }
}
