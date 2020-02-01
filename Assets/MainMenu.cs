using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject canvasMenu;
    [SerializeField] GameObject canvasCredits;
    [SerializeField] GameObject canvasTransition;
    [SerializeField] GameObject princess;
    [SerializeField] GameObject btnContinue;

    bool isPlaying = false;

    

    private void Start()
    {
        Cursor.visible = true;
        int theEnd = PlayerPrefs.GetInt("EndGame");
        if (theEnd == 1)
        {
            princess.SetActive(true);
            btnContinue.SetActive(false);
        }
        else
        {
            princess.SetActive(false);
            btnContinue.SetActive(PlayerPrefs.GetInt("Stage") > 0);
        }
    }

    public void ClickButtonCredits()
    {
        if (!isPlaying){ canvasCredits.SetActive(true); }
    }

    public void ClickButtonPlay()
    {
        isPlaying = true;
        canvasTransition.SetActive(true);
        PlayerPrefs.SetInt("Stage", 0);
        PlayerPrefs.SetInt("EndGame", 0);
        Invoke("StartGame", 1.4f);
    }

    public void ClickButtonContinue()
    {
        isPlaying = true;
        canvasTransition.SetActive(true);
        Invoke("StartGame", 1.4f);
    }

    public void ClickButtonExitGame()
    {
        if (!isPlaying){ Application.Quit(); }
    }

    public void CloseCanvasCredits()
    {
        canvasCredits.SetActive(false);
    }

    void StartGame()
    {
        SceneManager.LoadScene(4);
    }


}
