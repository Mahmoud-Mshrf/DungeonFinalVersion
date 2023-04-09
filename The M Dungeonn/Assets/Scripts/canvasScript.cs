using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasScript : MonoBehaviour
{
    public static bool GameIsPaused= false;
    public GameObject PauseMenuUI;
    public GameObject BackgroundMusic;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        BackgroundMusic.SetActive(true);

    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused= true;
        BackgroundMusic.SetActive(false);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
