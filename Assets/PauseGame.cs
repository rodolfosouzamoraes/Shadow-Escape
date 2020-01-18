using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject canvasPause;
    public bool paused = false;
    public void TogglePause()
    {
        paused = !paused;
        canvasPause.SetActive(paused);

        if (paused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
