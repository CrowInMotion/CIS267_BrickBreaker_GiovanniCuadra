using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rb;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private int playerLives;

    private float baseSpeed;

    private Vector2 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        baseSpeed = movementSpeed;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
    }

    public int getRemainingLives()
    {
        return playerLives;
    }

    public void changeLife (int lifeChange)
    {
        playerLives += lifeChange;
    }

    public void boostSpeed(int boost)
    {
        movementSpeed += boost;
    }

    public void resetSpeed()
    {
        movementSpeed = baseSpeed;
    }


    private void movePlayerLateral()
    {
        //if A/D/<-/-> are pressed move the player accordingly
        //"Horizontal" is defined in the input section fo the project settings
        //the line below will return:
        //0 - no button pressed
        //1 - right arrow or d
        //2 - left arror or a pressed
        float inputHorizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
        player_rb.linearVelocity = new Vector2(inputHorizontal * movementSpeed, player_rb.linearVelocityY);
    }

    public void resetPosition()
    {
        transform.position = startPosition;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 paddlePosition = transform.position;

            // Calculate distance from center (-1 to 1 value)
            float hitFactor = (contactPoint.x - paddlePosition.x) / GetComponent<Collider2D>().bounds.size.x;

            //This changes the ball direction depending on the current player velocity and point hit 
            Vector2 direction = new Vector2(hitFactor, 1).normalized;
            ballRb.linearVelocity = direction * ballRb.linearVelocity.magnitude;
        }
    }
}
