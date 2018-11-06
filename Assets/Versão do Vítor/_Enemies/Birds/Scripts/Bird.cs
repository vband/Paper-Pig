using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy
{
    [SerializeField] private float verticalAmplitude = 1f;
    [SerializeField] private float verticalSpeed = 1f;

    private float startTime, startHeight;

    private new void Start()
    {
        GetComponentInChildren<Animator>().SetBool("isFlying", true);

        float randomY = Random.Range(3, 8);

        startTime = Time.time;
        startHeight = randomY;
        transform.Translate(transform.position.x, randomY, transform.position.z);

        
        if (randomY >= 5)
        {
            float randomModifier = Random.Range(0, 3);
            verticalAmplitude += randomModifier;
            base.speed += randomModifier;
        }
    }

    private new void Update()
    {
        base.Update();

        transform.position = new Vector3(transform.position.x,
                                        startHeight + Mathf.Cos(verticalSpeed*(Time.time + startTime)) * verticalAmplitude,
                                        transform.position.z);
    }
}
