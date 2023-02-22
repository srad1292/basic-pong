using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] Ball ball;
    [SerializeField] Paddle player1;
    [SerializeField] Paddle player2;
    [SerializeField] TextMeshProUGUI player1ScoreText;
    [SerializeField] TextMeshProUGUI player2ScoreText;

    int player1Score = 0;
    int player2Score = 0;

    float paddleStartX = -16;

    int goalsToWin = 11;

    void ResetGame() {
        ResetScores();
        ResetPositions();
    }

    public void GoalScored(bool player1Goal) {
        if (player1Goal) {
            player2Score += 1;
            player2ScoreText.SetText(GetDisplayScore(player2Score));
        } else {
            player1Score += 1;
            player1ScoreText.SetText(GetDisplayScore(player1Score));
        }


        if(player1Score == goalsToWin || player2Score == goalsToWin) {
            ResetGame();
            ball.Launch();
        } else {
            ResetPositions();
            ball.Launch();
        }
    }

    private void ResetScores() {
        player1Score = 0;
        player2Score = 0;
        player1ScoreText.SetText(GetDisplayScore(player1Score));
        player2ScoreText.SetText(GetDisplayScore(player2Score));
    }

    void ResetPositions() {
        player1.ResetPosition(paddleStartX);
        player2.ResetPosition(Mathf.Round(-1 * paddleStartX));
        ball.ResetPosition();
    }

    string GetDisplayScore(int score) {
        return (score < 10 ? "0" : "") + score.ToString();
    }
    
}
