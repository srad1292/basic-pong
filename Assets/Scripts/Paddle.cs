using UnityEngine;


public class Paddle : MonoBehaviour {

    private enum PaddleType {Player1, Player2, Computer };

    [SerializeField]
    PaddleType paddleType;

    [SerializeField]
    float speed = 2f;

    [SerializeField]
    Ball ball;

    Rigidbody2D myRigidBody2D;

    float direction = 0f;

    float tolerance = 0.2f;

    private void Start() {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (paddleType == PaddleType.Player1) {
            direction = Input.GetAxisRaw("VerticalWS");
        }
        else if (paddleType == PaddleType.Player2) {
            direction = Input.GetAxisRaw("VerticalArrow");
        } else if(paddleType == PaddleType.Computer) {
            float yDistance = ball.gameObject.transform.position.y - gameObject.transform.position.y;
            if(Mathf.Abs(yDistance) > tolerance) {
                direction = Mathf.Sign(yDistance);
            } else {
                direction = 0f;
            }
            
        }
    }

    private void FixedUpdate() {
        myRigidBody2D.velocity = new Vector2(0, direction * speed);
    }

    public void ResetPosition(float xPosition) {
        gameObject.transform.position = new Vector2(xPosition, 0f);
        direction = 0f;
        myRigidBody2D.velocity = Vector2.zero;
    }

    
}
