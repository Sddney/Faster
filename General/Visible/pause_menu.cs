using UnityEngine;

public class pause_menu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;
    public bool canPause = true;
    public GameObject optionsMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private bool InOptions()
    {
       if (optionsMenu.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause && InOptions() == false)
        {
            if (isPaused)
            {
                Resume();
                isPaused = false;
            }
            else
            {
                PauseGame();
                isPaused = true;
            }
        }
    }
}
