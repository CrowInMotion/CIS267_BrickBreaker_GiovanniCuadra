using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ball_rb;
    private GameObject player;
    private bool isLaunched;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform paddle;

    public TMP_Text startPrompt;

    private GameManager gameManager;
    
    private Vector2 launchDirection;
    private Vector2 baseVelocity;

    private float randomX;
    private float randomNudge;
    private float currentX;
    private float currentY;

    private float baseSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball_rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBall();
    }

    private void moveBall()
    {
        if (!isLaunched)
        {
            lockBall();
        }
        else
        {
            //maintains speed of the ball after launch
            ball_rb.linearVelocity = ball_rb.linearVelocity.normalized * speed;
        }
    }

    public void lockBall()
    {
        startPrompt.alpha = 1f;
        Time.timeScale = 0f;

        isLaunched = false;

        // Keep the ball locked to the top of the paddle before launch
        transform.position = new Vector2(paddle.position.x, paddle.position.y + 0.5f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            launchBall();
            baseSpeed = speed;
        }
    }

    private void launchBall()
    {
        //Start prompt is hidden and time resumed
        startPrompt.alpha = 0f;
        Time.timeScale = 1f;

        isLaunched = true;

        //Ball is launched with a random push on the x value
        randomX = Random.Range(-0.5f, 0.5f);
        launchDirection = new Vector2(randomX, 1f).normalized;
        ball_rb.linearVelocity = launchDirection * speed;
        baseVelocity = ball_rb.linearVelocity;
    }

    public void boostSpeed(int boost)
    {
        speed = speed + boost;
    }
    
    public void resetSpeed()
    {
        speed = baseSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        currentX = ball_rb.linearVelocity.x;
        currentY = ball_rb.linearVelocity.y;

        //Pick a small random value
        randomNudge = Random.Range(-0.5f, 0.5f);

        //slightly pushes the in the opposite direction and down on left and right walls
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            ball_rb.linearVelocity = new Vector2(currentX + 1, currentY - 1);
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {

            ball_rb.linearVelocity = new Vector2(currentX - 1, currentY - 1);
        }

        //Adds randomly to the x direction, and pushes down on the y
        if (collision.gameObject.CompareTag("TopWall"))
        {
            ball_rb.linearVelocity = new Vector2(currentX + randomNudge, currentY - 2);
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            //Adds the player's velocity to the ball upon impact
            //this gives the player some level of control when hitting the ball
            ball_rb.linearVelocity = new Vector2(ball_rb.linearVelocityX + collision.rigidbody.linearVelocityX, ball_rb.linearVelocityY + 2); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Out Of Bounds"))
        {
            gameManager.loseLife();
        }
    }
}
