using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] AudioManager audioManager;

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
        myRigidBody2D.velocity = Vector2.zero;
        gameObject.transform.position = Vector2.zero;
    }

    public void Launch() {
        StartCoroutine(delayedLaunch());
    }

    private IEnumerator delayedLaunch() {
        yield return new WaitForSeconds(1.2f);
        int x = Random.Range(0, 2);
        float xDirection = x == 0 ? -1 : 1;

        int y = Random.Range(0, 2);
        float yDirection = y == 0 ? -1 : 1;

        directions = new Vector2(xDirection, yDirection);
        myRigidBody2D.velocity = new Vector2(directions.x * speed, directions.y * speed);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        audioManager.PlaySound(collision.gameObject.tag);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        audioManager.PlaySound(collision.tag);
    }


}
