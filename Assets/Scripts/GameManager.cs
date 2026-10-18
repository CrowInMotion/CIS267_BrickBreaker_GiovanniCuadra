using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text finalScore;
    public TMP_Text playerLives;

    private PlayerScore playerScore;
    private BallController ballControllerScript;
    private PlayerController playerControllerScript;
    private GUIButtonHandler menuScript;

    private int remainingBlocks;

    private GameObject[] effectsOnScreen;
    private GameObject[] duplicateBalls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Hides final score
        finalScore.alpha = 0f;

        ballControllerScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        menuScript = GameObject.FindGameObjectWithTag("Menu").GetComponent<GUIButtonHandler>();
        playerScore = gameObject.GetComponent<PlayerScore>();

        menuScript.hideAllMenus();
    }

    // Update is called once per frame
    void Update()
    {
        //This list keeps track of the effect collectibles and duplicate balls that are currently spawned
        effectsOnScreen = GameObject.FindGameObjectsWithTag("Effect");
        duplicateBalls = GameObject.FindGameObjectsWithTag("BallDuplicate");

        checkLives();
    }

    public void checkTotalBlocks(int blocksRemaining)
    {
        remainingBlocks = blocksRemaining;
    }

    public void loseLife()
    {
        //The playerControllerScript adjusts the remaining lives of the player
        playerControllerScript.changeLife(-1);

        //Clears on screen effects
        clearEffects();

        //Resets ball and player positions and speeds
        ballControllerScript.lockBall();
        ballControllerScript.resetSpeed();
        playerControllerScript.resetPosition();
        playerControllerScript.resetSpeed();
    }

    //The ballcontroller script calls this when the ball goes out of bounds
    public void checkLives()
    {
        //The player lives GUI display is adjusted to reflect remaining lives
        playerLives.text = "Lives: " + playerControllerScript.getRemainingLives().ToString();

        
        if (playerControllerScript.getRemainingLives() <= 0)
        {
            gameOver();
        }
    }

    //Clears on screen effects when the ball goes out of bounds
    private void clearEffects()
    {
        for (int i = 0; i < effectsOnScreen.Length; i++)
        {
            Destroy(effectsOnScreen[i]);
        }
        for (int i = 0; i < duplicateBalls.Length; i++)
        {
            Destroy(duplicateBalls[i]);
        }
    }

    //Block controller calls this when a block is broken
    public void blockBroke()
    {
        //Whenever a block breaks, remove from total
        //If there's no block remaining then the game is over
        remainingBlocks--;
        checkWin();
    }

    //If no blocks remain, the game is over
    public void checkWin()
    {
        if (remainingBlocks == 0)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        menuScript.showGameOver();
        showFinalScore();
    }

    public void updateFinalScore()
    {
        finalScore.text = "Final Score: " + playerScore.getScore().ToString();
    }

    public void showFinalScore()
    {
        //Change final score to visible
        finalScore.alpha = 1f;

        //high score
        if (playerScore.getScore() > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", playerScore.getScore());
            Debug.Log("New Highscore");
        }
    }
}
