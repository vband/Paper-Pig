using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LayerBehaviour layer0;
    [SerializeField] LayerBehaviour layer1;

    private int currentLayer = 0;

    private void Start()
    {
        //ChangeLayer(currentLayer);
    }

    public int GetCurrentLayer()
    {
        return currentLayer;
    }

    public void ChangeLayer(int targetLayer)
    {
        if (targetLayer == 0)
        {
            layer1.MakeShadowy();
            layer0.Restore();
            currentLayer = 0;
        }
        else if (targetLayer == 1)
        {
            layer0.MakeTransparent();
            layer1.Restore();
            currentLayer = 1;
        }
    }

    public void LoseGame()
    {
        if (Score.score > PlayerPrefs.GetFloat("High Score", 0f))
        {
            Score.highScore = Score.score;
            PlayerPrefs.SetFloat("High Score", Score.highScore);
        }

        FindObjectOfType<GameOverMenuController>().GameOver();
    }
}
