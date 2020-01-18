using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEgg : MonoBehaviour
{
    int totalBatteryInGame;
    int totalCaverudo;
    // Start is called before the first frame update
    void Start()
    {
        totalBatteryInGame = GameObject.FindGameObjectsWithTag("Battery").Length;
        totalCaverudo = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MovimentPlayer>().isAlive)
        {
            PlayerPrefs.SetInt("TotalBatteryCollected", totalBatteryInGame);
            PlayerPrefs.SetInt("CaverudosDeath", totalCaverudo);
            SceneManager.LoadScene(3);
        }
        
    }
}
