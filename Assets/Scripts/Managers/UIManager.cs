using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button pauseButton;
    private int player1Score = 0;
    private int player2Score = 0;



    [SerializeField] private int maxScore = 20;
    public int MaxScore => maxScore;

    public GameObject menuBG;
    [SerializeField] private MenuScreenController menuScreenController;

    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;

    
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI winScreenText;

    public bool isGamePause = false;
    public bool isInMainMenu = true;

    public static UIManager manager;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void ShowMenuScreen(bool _isGamePause = false)
    {
        isGamePause = _isGamePause;
        menuScreenController.gameObject.SetActive(true);
        menuScreenController.SetButtonsStatus();
        Time.timeScale = 0f;
        this.gameObject.SetActive(false);
    }

    #region [ ======== Scoring Functionality ========]

    public void IncrementPlayerOneScore()
    {
        player1Score++;
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
    }

    public void IncrementPlayerTwoScore()
    {
        player2Score++;
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
        CheckPlayerWins();
    }

    private void CheckPlayerWins()
    {
        if(player1Score >= maxScore)
        {
            winScreenText.text = "Player 1 Wins";
            ShowMenuScreen();
        }
        else if(player2Score >= maxScore)
        {
            isGamePause = false;
            winScreenText.text = "Player 2 Wins";
            ShowMenuScreen();
        }
    }

    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
    }

    #endregion
}
