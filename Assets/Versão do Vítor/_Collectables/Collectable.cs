using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] protected int points = 1;
    [SerializeField] private float speed = 3f;

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
        if (transform.position.x <= 20f)
        {
            Destroy(gameObject);
        }
    }
}
