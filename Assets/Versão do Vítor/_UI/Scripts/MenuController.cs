using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour {

    [SerializeField] private Image fadeImage;
    [SerializeField] private GameObject fadeImageGO;
    [SerializeField] private float screenFadeStartTime;
    [SerializeField] private float screenFadeDuration;
    [SerializeField] private float gdpFadeDuration;

    private void Start()
    {
        //StartCoroutine("Fade");
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
        //FindObjectOfType<BackgroundMusic>().ChangeSong(Scene.Game);
        DontDestroyOnLoader.hasGameStarted = true;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Fade()
    {
        //fadeImageGO.SetActive(true);
        Sequence seq = DOTween.Sequence();

        seq.Insert(screenFadeStartTime, fadeImage.DOFade(0f, screenFadeDuration));
        seq.Play();
        DontDestroyOnLoader.hasGameStarted = true;
        //yield return seq.WaitForCompletion();
    }
}
