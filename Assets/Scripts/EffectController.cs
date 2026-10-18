using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D effect_rb;

    private GameObject player;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect_rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDown();
    }

    public void setRandomSpeed()
    {
        float minSpeed = 3;
        float maxSpeed = 10;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void moveDown()
    {
        effect_rb.linearVelocity = new Vector2(0, speed * -1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(this.gameObject);
        }

        else if (collision.gameObject == GameObject.FindGameObjectWithTag("Out Of Bounds"))
        {
            Destroy(this.gameObject);
        }
    }
}
