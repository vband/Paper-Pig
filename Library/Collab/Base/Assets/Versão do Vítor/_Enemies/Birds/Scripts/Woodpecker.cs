using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodpecker : Bird {

    private bool fly = false;

    private new void Start()
    {
        base.Start();
    }

	private new void Update()
    {
        
        if (fly)
            base.Update();
    }

    private bool Fly(float chance)
    {
        if ((chance >= 2 && chance <= 4))
            return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        float flyChance = Random.Range(0, 5);
        if (col.gameObject.CompareTag("FlyPoint") && Fly(flyChance))
            fly = true;
    }
}
