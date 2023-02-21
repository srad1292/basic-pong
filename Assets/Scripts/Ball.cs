using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Rigidbody2D myRigidBody2D;
    Vector2 directions;

    private void Start() {
        directions = Vector2.zero;
        myRigidBody2D = GetComponent<Rigidbody2D>();
        ResetPosition();
        Launch();
    }

    public void ResetPosition() {
        directions = Vector2.zero;
        gameObject.transform.position = Vector2.zero;
    }

    public void Launch() {
        int x = Random.Range(0, 1);
        float xDirection = x == 0 ? -1 : 1;

        int y = Random.Range(0, 1);
        float yDirection = y == 0 ? -1 : 1;

        directions = new Vector2(xDirection, yDirection);
        myRigidBody2D.velocity = new Vector2(directions.x * speed, directions.y * speed);
    }

    
}
