using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    public void LoadSceneMenu()
    {
        foreach(GameObject go in gameObjects)
        {
            Destroy(go);
        }
        PlayerPrefs.SetInt("EndGame", 1);
        SceneManager.LoadScene(0);
    }
}
