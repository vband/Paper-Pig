using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 1;

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        // Movimento horizontal
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        Despawn();
    }

    private void Despawn()
    {
        if (transform.position.x <= -20f)
        {
            Destroy(gameObject);
        }
    }
}
