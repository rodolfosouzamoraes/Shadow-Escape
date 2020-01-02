using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ManageTheEnd : MonoBehaviour
{
    [SerializeField] Tilemap shadowTilemap;
    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        // ShadowDown();
        Invoke("StartStage", 3f);
    }

    private void StartStage()
    {
        player.GetComponent<MovimentPlayer>().isAlive = true;
        boss.GetComponent<Animator>().SetBool("Boss", true);
    }

    private void ShadowDown()
    {
        int totalBattery = PlayerPrefs.GetInt("TotalBattery");
        int totalBatteryCollected = PlayerPrefs.GetInt("TotalBatteryCollected");
        float valueShadow = (255 / totalBattery) * totalBatteryCollected;
        shadowTilemap.color = new Color(0, 0, 0, 1 - (valueShadow / 255));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
