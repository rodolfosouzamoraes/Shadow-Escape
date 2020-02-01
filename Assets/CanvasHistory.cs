using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasHistory : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.GetInt("Stage") > 0)
        {
            StartSceneGame();
        }
    }
    public void StartSceneGame()
    {
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSceneGame();
        }
    }
}
