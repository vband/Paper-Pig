using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scene { Menu, Game };

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip startMenuClip;
    [SerializeField] private AudioClip loopMenuClip;
    [SerializeField] private AudioClip startGameClip;
    [SerializeField] private AudioClip loopGameClip;

    public Scene scene = Scene.Menu;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (scene == Scene.Menu)
        {
            audioSource.clip = startMenuClip;
        }
        else if (scene == Scene.Game)
        {
            audioSource.clip = startGameClip;
        }
        audioSource.loop = false;
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (scene == Scene.Menu)
            {
                audioSource.clip = loopMenuClip;
            }
            else if (scene == Scene.Game)
            {
                audioSource.clip = loopGameClip;
            }
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeSong(Scene s)
    {
        scene = s;
        audioSource.Stop();
        Start();
    }
}
