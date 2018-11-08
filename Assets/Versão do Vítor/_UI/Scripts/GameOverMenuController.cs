using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioClip highScoreClip;

    public void PlayAgain()
    {
        FindObjectOfType<BackgroundMusic>().GetComponent<AudioSource>().volume = 1;
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        scoreText.text = scoreText.text + string.Format("{0:0}", Score.score);
        highScoreText.text = highScoreText.text + string.Format("{0:0}", Score.highScore);
        
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;

        AudioSource audioSouce = FindObjectOfType<PlayerDeath>().GetComponent<AudioSource>();
        audioSouce.Stop();
        if (Score.score == Score.highScore)
        {
            audioSouce.clip = highScoreClip;
        }
        else
        {
            audioSouce.clip = gameOverClip;
        }
        BackgroundMusic bgMusic = FindObjectOfType<BackgroundMusic>();
        bgMusic.GetComponent<AudioSource>().volume = 0.2f;
        audioSouce.loop = true;
        audioSouce.Play();
    }

    public void Menu()
    {
        FindObjectOfType<BackgroundMusic>().ChangeSong(Scene.Menu);
        FindObjectOfType<BackgroundMusic>().GetComponent<AudioSource>().volume = 1;
        DontDestroyOnLoader.hasPlayedIntro = false;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
