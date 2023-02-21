using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] Ball ball;
    [SerializeField] Paddle player1;
    [SerializeField] Paddle player2;

    float paddleStartX = -19;

    void ResetGame() {
        ResetPositions();
    }

    public void GoalScored(bool player1Goal) {
        // update correct goal text
        
        ResetPositions();
    }

    void ResetPositions() {
        player1.ResetPosition(paddleStartX);
        player2.ResetPosition(Mathf.Round(-1 * paddleStartX));
        ball.ResetPosition();
        ball.Launch();
    }
    
}
