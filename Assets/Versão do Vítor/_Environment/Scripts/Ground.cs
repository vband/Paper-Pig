using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private GameManager gameManager;
    private int myLayer;
    private SpriteRenderer sprite;
    private Collider2D col;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        myLayer = GetComponentInParent<LayerBehaviour>().GetLayer();
        col= GetComponent<Collider2D>();

        if (myLayer == 0 && gameManager.GetCurrentLayer() != 0)
        {
            // Transparente
            MakeSpriteTransparent();
            if (col != null) col.enabled = false;
        }
        else if (myLayer == 1 && gameManager.GetCurrentLayer() != 1)
        {
            // Sombroso (futuro mudar)
            MakeSpriteTransparent();
            if (col != null) col.enabled = false;
        }

        if (myLayer == 0)
        {
            sprite.sortingOrder += 10;
        }
    }

    private void MakeSpriteTransparent()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
    }
}
