using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    bool player1Goal = false;

    [SerializeField]
    GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ball") {
            gameManager.GoalScored(player1Goal);
        }    
    }
}
