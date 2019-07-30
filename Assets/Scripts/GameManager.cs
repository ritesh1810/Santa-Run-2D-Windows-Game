using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 

    public static GameManager instance;

    public GameObject gameOverPanel;
    public GameObject pauseMenuPanel;

    public Text scoreText;
    int score = 0;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }


    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }
    void StopScrolling()
    {

       TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach (TextureScroll t in scrollingObjects)
        {
            t.scroll = false;
        }
    }

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void IncrementScore()
    {
        score++;
        //print(score);

        scoreText.text = score.ToString();
    }


}

