using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    //these will be used to determine where to spawn the collectable
    //I will get these values from the empty gameObjects we created by referencing their x and y values
    public GameObject maxLeftSpawn;
    public GameObject maxRightSpawn;

    //These are public variables that allow me to drag and drop our prefabs
    public GameObject fastBallEffect;
    public GameObject fastPaddleEffect;
    public GameObject loseLifeEffect;

    [SerializeField]
    private float minDelay;
    [SerializeField]
    private float maxDelay;

    //random number to determine which of the collectables to spawn
    private int randomNum;

    //which collectable to spawn
    private GameObject effectToSpawn;

    //we need a reference to time so we can determine how often to spawn a collectable
    private float time;

    //we need a delay to specify how long to wait between spawns
    //public float delay;

    private float delay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rollDelay();
    }

    // Update is called once per frame
    void Update()
    {
        //add to time. see how much time has passed since the last frame

        time += Time.deltaTime;

        if (time >= delay)
        {
            spawnObject();
            //reset our timer to 0
            time = 0f;
        }
    }

    private void rollDelay()
    {
        delay = Random.Range(minDelay, maxDelay);
    }

    private void spawnObject()
    {
        //get a random number to determine which effect to spawn
        randomNum = Random.Range(0, 3);

        if (randomNum == 0)
        {
            //if the number is 0, spawn a blue collectable
            effectToSpawn = Instantiate(fastBallEffect);
        }
        else if (randomNum == 1)
        {
            //if the number is 1, spawn a purple collectable
            effectToSpawn = Instantiate(fastPaddleEffect);
        }
        else if (randomNum == 2)
        {
            //if the number is 2, spawn a red collectable
            effectToSpawn = Instantiate(loseLifeEffect);
        }

        //tell the collectible where to spawn
        effectToSpawn.transform.position = new Vector2(Random.Range(maxLeftSpawn.transform.position.x,maxRightSpawn.transform.position.x), maxLeftSpawn.transform.position.y);
    }
}
