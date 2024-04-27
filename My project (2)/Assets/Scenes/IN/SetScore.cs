using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SetScore : MonoBehaviour
{
    [Header("Setting Score")]
    public static int scoreP1;
    public static int scoreP2;


    public bool GetScoreP1 = false;
    public bool GetScoreP2 = false;

    [Header("Win or Lose")]
    public bool Player1Win = false;
    public bool Player2Win = false;

    [Header("GameObject")]
    public bool ballIsMoving;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI ScoreText1;
    [SerializeField] TextMeshProUGUI ScoreText2;

    public static int score1Previous;
    public static int score2Previous;

    public string scenePlayer1Win;
    public string scenePlayer2Win;

    void Start()
    {
        Debug.Log("Start Program");
        GetScoreP1 = false;
        GetScoreP2 = false;
        Player1Win = false;
        Player2Win = false;
        scoreP1 = 0;
        scoreP2 = 0;
    }

    

    void Update()
    {
        SettingScore();
    }

    void SettingScore()
    {
        ScoreText1.text = scoreP1.ToString();
        ScoreText2.text = scoreP2.ToString();
        
        if (GetScoreP1)
        {
            scoreP1 += 1;
            GetScoreP1 = false;
        }

        if (GetScoreP2)
        {
            scoreP2 += 1;
            GetScoreP2 = false;
        }

        //------------------------------------------------

        if (scoreP1 >= 7)
        {
            Player1Win = true;
            scoreP1 = 7;
            ballIsMoving = false;
            Debug.Log("Player 1 Victory");
            player1win();
        }

        if (scoreP2 >= 7)
        {
            Player2Win = true;
            scoreP2 = 7;
            ballIsMoving = false;
            Debug.Log("Player 2 Victory");
            player2win();
        }
    }

    public void player2win()
    {
        SceneManager.LoadScene(scenePlayer2Win);
    }

    public void player1win()
    {
        SceneManager.LoadScene(scenePlayer1Win);
    }
}
