using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScale : MonoBehaviour
{
    [SerializeField] List<EnemySpawner> spawners;
    [SerializeField] float timeIntervalInSeconds = 20f;
    [SerializeField] float frequencyDecrease = 0.2f;

    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0f;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeIntervalInSeconds)
        {
            foreach (EnemySpawner spawner in spawners)
            {
                spawner.TimeIntervalMax -= frequencyDecrease;
                spawner.TimeIntervalMin -= frequencyDecrease;
            }

            elapsedTime = 0f;
        }
    }
}
