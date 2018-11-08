using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        if (!DontDestroyOnLoader.hasPlayedIntro)
        {
            anim = GetComponent<Animator>();
            Time.timeScale = 0f;
            FindObjectOfType<BackgroundMusic>().ChangeSong(Scene.Game);
            anim.Play("Intro");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnAnimationFinished()
    {
        DontDestroyOnLoader.hasPlayedIntro = true;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
