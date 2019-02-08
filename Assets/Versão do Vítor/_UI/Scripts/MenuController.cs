using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour {

    [SerializeField] private Image fadeImage;
    [SerializeField] private float screenFadeStartTime;
    [SerializeField] private float screenFadeDuration;

    private void Start()
    {
        fadeImage.DOFade(1, 0);

        if (!DontDestroyOnLoader.hasGameStarted)
        {
            Fade();
        }
        else
        {
            fadeImage.gameObject.SetActive(false);
        }
    }

    public void Play()
    {
        DontDestroyOnLoader.hasGameStarted = true;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Fade()
    {

        Sequence seq = DOTween.Sequence();
        seq.Insert(screenFadeStartTime, fadeImage.DOFade(0f, screenFadeDuration));
        seq.Play();
        DontDestroyOnLoader.hasGameStarted = true;
    }
}
