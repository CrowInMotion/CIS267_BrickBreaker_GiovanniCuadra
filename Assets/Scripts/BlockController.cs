using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField]
    private int maxHits;

    [SerializeField]
    private int blockValue;

    private GameObject gameManager;
    private GameManager gameManagerScript;
    private PlayerScore playerScoreScript;

    private int curHits;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        playerScoreScript = gameManager.GetComponent<PlayerScore>();
        curHits = 0;
    }

    public int getRemainingHits()
    {
        int remainingHits = maxHits - curHits;
        return remainingHits;
    }

    //If the block has a corresponding effect, activate it
    private void activateEffect()
    {
        if (CompareTag("SpecialBlock"))
        {
            GetComponent<DuplicateBall>().duplicateBall();
        }

        if (CompareTag("ToughBlock"))
        {
            GetComponent<ExtraLife>().addLife();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("BallDuplicate"))
        {
            //When a block is hit by the ball, this keeps track of how many times it's already been hit
            curHits += 1;

            //Once the block has reached max hits
            //this let's game manager know that the block was broke, passes the block value to player score, then destroys the block
            if (curHits >= maxHits)
            {
                gameManagerScript.blockBroke();
                activateEffect();
                playerScoreScript.setPlayerScore(blockValue);
                gameManagerScript.updateFinalScore();
                Destroy(this.gameObject);
            }
        }
    }
}
