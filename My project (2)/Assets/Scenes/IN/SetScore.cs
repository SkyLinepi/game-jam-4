using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class SetScore : MonoBehaviour
{
    [Header("Setting Score")]
    [SerializeField] private int scoreP1;
    [SerializeField] private int scoreP2;

    public bool GetScoreP1 = false;
    public bool GetScoreP2 = false;

    [Header("Win or Lose")]
    public bool Player1Win = false;
    public bool Player2Win = false;

    [Header("GameObject")]
    public bool ballIsMoving;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI ScoreText;

    void Start()
    {
        Debug.Log("Start Program");
        GetScoreP1 = false;
        GetScoreP2 = false;
        Player1Win = false;
        Player2Win = false;
    }

    void Update()
    {
        SettingScore();
    }

    void SettingScore()
    {
        ScoreText.text = string.Format("{0:0} : {1:0}", scoreP1, scoreP2);

        if (GetScoreP1)
        {
            scoreP1 += 1;
            GetScoreP1 = false;
            Debug.Log("Player 1 Score: " + scoreP1);
        }

        if (GetScoreP2)
        {
            scoreP2 += 1;
            GetScoreP2 = false;
            Debug.Log("Player 2 Score: " + scoreP2);
        }

        //------------------------------------------------

        if (scoreP1 >= 7)
        {
            Player1Win = true;
            scoreP1 = 7;
            ballIsMoving = false;
            Debug.Log("Player 1 Victory");
        }

        if (scoreP2 >= 7)
        {
            Player2Win = true;
            scoreP2 = 7;
            ballIsMoving = false;
            Debug.Log("Player 2 Victory");
        }

    }
}
