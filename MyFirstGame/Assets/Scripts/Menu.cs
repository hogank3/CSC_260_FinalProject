using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public GameObject menu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
            toggleMenu();
        }
    }

    public void pauseGame()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            toggleMenu();
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            toggleMenu();
        }
    }

    private void toggleMenu()
    {
        menu.SetActive(isPaused);
    }

    public void restartGame()
    {
        pauseGame();
        SceneManager.LoadScene("GameScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
