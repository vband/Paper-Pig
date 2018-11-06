using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Enemy
{
    [SerializeField] private float verticalAmplitude = 1f;
    [SerializeField] private float verticalSpeed = 0.3f;

    private float startTime, startHeight;

    private new void Start()
    {
        startTime = Time.time;
        startHeight = transform.position.y;
    }

    private new void Update()
    {
        base.Update();

        transform.position = new Vector3(transform.position.x,
                                        startHeight + Mathf.Cos(/*verticalSpeed **/ Time.time) * verticalAmplitude,
                                        transform.position.z);
    }
}
