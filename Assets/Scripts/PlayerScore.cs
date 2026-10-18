using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //attached to game manager
    //drag connection for guiScore
    //when we get a collectible call this script to incremement/set score
    private int playerScore;
    public TMP_Text guiScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScore = 0;
    }

    public void setPlayerScore(int val)
    {
        playerScore += val;
        setGUIPlayerScore();
    }

    public int getScore()
    {
        return playerScore;
    }

    public void setGUIPlayerScore()
    {
        guiScore.text = "Score: ";
        guiScore.text += playerScore.ToString();
    }
}