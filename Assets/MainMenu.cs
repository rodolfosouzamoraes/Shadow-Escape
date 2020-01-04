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

    bool isPlaying = false;

    

    private void Start()
    {
        int theEnd = PlayerPrefs.GetInt("EndGame");
        if (theEnd == 1)
        {
            princess.SetActive(true);
        }
        else
        {
            princess.SetActive(false);
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
        SceneManager.LoadScene(3);
    }


}
