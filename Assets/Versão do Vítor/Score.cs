using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static float score;
    public static float highScore;

    private void Start()
    {
        score = 0f;
        highScore = PlayerPrefs.GetFloat("High Score", 0f);
    }

    private void Update()
    {
        score += Time.deltaTime;
    }
}
