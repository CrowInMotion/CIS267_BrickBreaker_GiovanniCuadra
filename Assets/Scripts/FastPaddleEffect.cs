using UnityEngine;

public class FastPaddleEffect : MonoBehaviour
{
    [SerializeField]
    private int paddleSpeedBoost;
    [SerializeField]
    private float timeToExpire;

    private float timer;

    public bool isEnabled = false;

    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getPaddleSpeedBoost()
    {
        return paddleSpeedBoost;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;

            player.GetComponent<PlayerController>().boostSpeed(paddleSpeedBoost);
            Debug.Log("Paddle speed boost by " + paddleSpeedBoost.ToString());
        }
    }
}
