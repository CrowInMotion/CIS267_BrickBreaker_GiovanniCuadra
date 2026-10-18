using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockStandard;
    public GameObject blockTough;
    public GameObject blockFragile;
    public GameObject blockSpecial;


    [SerializeField]
    private int maxToughBlocks;

    [SerializeField]
    private int maxFragileBlocks;
    [SerializeField]
    private int maxSpecialBlocks;

    private GameObject blockToSpawn;

    private List<GameObject> blockList;


    private int randomNum;
    private int totalBlocksToSpawn = 0;

    private int curToughBlocks = 0;
    private int curFragileBlocks = 0;
    private int curSpecialBlocks = 0;
    private int totalBlocks = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Creates a list of all spawn locations
        blockList = new List<GameObject>();
        fillBlockList();

        for (int i = 0; i < totalBlocksToSpawn; i++)
        {
            //Randomly chooses which block to spawn
            rollSpawn();

            //Sets spawn position using the next spawn block in the list
            blockToSpawn.transform.position = new Vector2(blockList[i].transform.position.x, blockList[i].transform.position.y);

            //Keeps track of how many blocks were spawned
            totalBlocks += 1;
        }

        //Passes total blocks counted to gamemanager
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().checkTotalBlocks(totalBlocks);
 
    }

    private void fillBlockList()
    {
        GameObject[] spawnBlocks = GameObject.FindGameObjectsWithTag("SpawnBlock");

        foreach (GameObject sblock in spawnBlocks)
        {
            blockList.Add(sblock);
            totalBlocksToSpawn += 1;
        }
    }

    private void rollSpawn()
    {
        randomNum = Random.Range(0, 4);

        //Checks set max amount of each block type before spawning, allowing the max value to be adjustable
        if (randomNum == 1 && curToughBlocks < maxToughBlocks && maxToughBlocks != 0)
        {
            curToughBlocks += 1;
            blockToSpawn = Instantiate(blockTough);
        }
        else if (randomNum == 2 && curFragileBlocks < maxFragileBlocks && maxFragileBlocks != 0)
        {
            curFragileBlocks += 1;
            blockToSpawn = Instantiate(blockFragile);
        }
        else if (randomNum == 3 && curSpecialBlocks < maxSpecialBlocks && maxSpecialBlocks != 0)
        {
            curSpecialBlocks += 1;
            blockToSpawn = Instantiate(blockSpecial);
        }
        else
        {
            blockToSpawn = Instantiate(blockStandard);
        }
    }
}
