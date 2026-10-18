using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    //public GameObject menu;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    private bool sceneLoaded = false;
    private bool gamePaused = false;

    public string[] levelSceneNames;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);

        //Start with pause and gameover menu's disabled
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        showPauseMenu();
    }

    public void loadGame()
    {
        //need a way to ensure that this menu does not get destroyed between scene loads
        //DontDestroyOnLoad(gameObject);

        //Ensures that pause and game over menus are disabled whenever hitting play
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);

        Debug.Log("Hide all menus");

        ////need a way to ensure that this menu does not get destroyed between scene loads
        DontDestroyOnLoad(gameObject);

        //set bool to say the scene has been loaded
        //sceneLoaded = true;
        loadRandomScene();
    }

    public void loadRandomScene()
    {
        if (levelSceneNames.Length == 0)
        {
            Debug.LogWarning("No scenes assigned to the array!");
            return;
        }

        // Pick a random index from 0 to the length of the array
        int randomIndex = Random.Range(0, levelSceneNames.Length);

        // Load the randomly chosen scene name
        SceneManager.LoadScene(levelSceneNames[randomIndex]);

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);

        sceneLoaded = true;

    }

    public void hideAllMenus()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Exit Application..");
    }

    public void showGameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void showPauseMenu()
    {
        //look and see if the user paused the game
        if (Input.GetKeyDown(KeyCode.P) && sceneLoaded)
        {
            if (!gamePaused)
            {
                pauseMenu.SetActive(true);

                //actually pause the game
                Time.timeScale = 0;
                gamePaused = true;
            }
            else
            {
                resumeGame();
            }
        }
    }
}
