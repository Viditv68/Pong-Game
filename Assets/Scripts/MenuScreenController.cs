using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenController : MonoBehaviour
{

    #region [======= Button Variables =========]
    [SerializeField] private Button playButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button resetButton;
    #endregion

    [SerializeField] private SphereController sphereController;
    
    private UIManager uiManager => UIManager.manager;



    private void Start()
    {
        SetButtonsStatus();
    }

 
    #region [============ Button===========]
    public void PlayGame()
    {
        sphereController.gameObject.SetActive(true);
        uiManager.ResetScore();
        DisablMenuScreen();
    }


    public void ResumeGame()
    {
        DisablMenuScreen();
    }

    public void ResetGame()
    {
        sphereController.resetSpherePosition();
        DisablMenuScreen();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    public void SetButtonsStatus()
    {
        playButton.gameObject.SetActive(!uiManager.isGamePause);
        resetButton.gameObject.SetActive(uiManager.isGamePause);
        resumeButton.gameObject.SetActive(uiManager.isGamePause);
    }
    private void DisablMenuScreen()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        uiManager.isGamePause = false;
        uiManager.pauseButton.gameObject.SetActive(true);
    }
}
