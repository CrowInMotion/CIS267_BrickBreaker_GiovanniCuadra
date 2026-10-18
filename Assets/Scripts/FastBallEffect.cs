using UnityEngine;

public class FastBallEffect : MonoBehaviour
{
    [SerializeField]
    private int ballSpeedBoost;
    [SerializeField]
    private float timeToExpire;

    private GameObject ball;
    private BallController ballControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballControllerScript = ball.GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeBoost()
    {
        int negativeBoost = ballSpeedBoost * -1;
        ballControllerScript.boostSpeed(negativeBoost);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ballControllerScript.boostSpeed(ballSpeedBoost);

            GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }
}
