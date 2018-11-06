using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject game;

    private Animator anim;

    private void Start()
    {
        game.SetActive(false);

        anim = GetComponent<Animator>();
        Time.timeScale = 0f;
    }

    public void OnAnimationFinished()
    {
        game.SetActive(true);

        Time.timeScale = 1f;
        Destroy(transform.parent.gameObject);
    }
}
