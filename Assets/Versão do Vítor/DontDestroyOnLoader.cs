using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoader : MonoBehaviour
{
    public static bool hasGameStarted = false;
    public static bool hasPlayedIntro = false;

    private void Awake()
    {
        DontDestroyOnLoader other = FindObjectOfType<DontDestroyOnLoader>();

        if (other.gameObject != gameObject)
        {
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
