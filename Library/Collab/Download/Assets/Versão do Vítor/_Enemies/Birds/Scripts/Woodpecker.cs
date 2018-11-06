using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodpecker : Bird {

    [SerializeField] private float amplitudeVertical = 1f;
    [SerializeField] private float velocidadeVertical = 1f;

    private float tempoInicial, alturaInicial;

    private bool fly = false;

    private new void Start()
    {
        alturaInicial = transform.position.y;
    }

    private new void Update()
    {
        if (fly)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x,
                                        alturaInicial + Mathf.Cos(velocidadeVertical * (Time.time - tempoInicial + Mathf.PI/2)) * amplitudeVertical,
                                        transform.position.z);
        }
    }

    private void RandomizeMovement()
    {
            float randomModifier = Random.Range(0, 1.5f);
            amplitudeVertical += randomModifier;
            speed += randomModifier;
    }

    private bool Fly(float chance)
    {
        if ((chance >= 2 && chance <= 5))
            return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        float flyChance = Random.Range(0, 5);
        if (col.gameObject.CompareTag("FlyPoint") && (Fly(flyChance)))
        {
            RandomizeMovement();
            tempoInicial = Time.time;
            fly = true;
            GetComponentInParent<Tree>().StopPooping();
            transform.parent = null;
        }

    }
}
