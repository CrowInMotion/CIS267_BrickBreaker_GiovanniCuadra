using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private GameObject ballOriginal;

    private Rigidbody2D ball_rb;

    private float randomNudge;
    private float currentX;
    private float currentY;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballOriginal = GameObject.FindGameObjectWithTag("Ball");
        //ball_rb.linearVelocity = ballOriginal.GetComponent<Rigidbody2D>().linearVelocity;
        ball_rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentX = ball_rb.linearVelocity.x;
        currentY = ball_rb.linearVelocity.y;;

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            ball_rb.linearVelocity = new Vector2(currentX + 1, currentY);
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {

            ball_rb.linearVelocity = new Vector2(currentX - 1, currentY);
        }

        if (collision.gameObject.CompareTag("TopWall"))
        {

            ball_rb.linearVelocity = new Vector2(currentX + randomNudge, currentY - 1);
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
            Destroy(this.gameObject);
        }
    }
}
