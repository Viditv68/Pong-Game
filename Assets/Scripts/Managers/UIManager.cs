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


    [SerializeField] private MenuScreenController menuScreenController;

    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;

    public bool isGamePause = false;

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
    public void OnGamepause()
    {
        isGamePause = true;
        menuScreenController.gameObject.SetActive(true);
        menuScreenController.SetButtonsStatus();
        Time.timeScale = 0f;
        this.gameObject.SetActive(false);
    }

    public void IncrementPlayerOneScore()
    {
        player1Score++;
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
    }

    public void IncrementPlayerTwoScore()
    {
        player2Score++;
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
    }
}
