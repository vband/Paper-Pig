using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LayerBehaviour : MonoBehaviour
{
    [SerializeField] private int layer;
    [SerializeField] private float layerTransitionDuration = 0.3f;

    public int GetLayer()
    {
        return layer;
    }

    public void MakeTransparent()
    {
        MakeSpritesTransparent();
        TurnCollidersOnOff(false);
    }

    public void MakeShadowy()
    {
        MakeSpritesTransparent();
        TurnCollidersOnOff(false);
    }

    public void Restore()
    {
        RestoreSprites();
        TurnCollidersOnOff(true);
    }

    private void MakeSpritesTransparent()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.6f),
                           layerTransitionDuration);
        }
    }

    private void TurnCollidersOnOff(bool enabled)
    {
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = enabled;
        }
    }

    private void MakeSpritesShadowy()
    {
        // Por enquanto não temos
    }

    private void RestoreSprites()
    {
        // Teremos que mexer nisso no futuro, quando tivermos o MakeSpritesShadowy()
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f),
                           layerTransitionDuration);
        }
    }
}
