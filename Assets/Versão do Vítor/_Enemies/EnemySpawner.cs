using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip ("Limite inferior do intervalo de tempo entre spawns.")]
    [SerializeField] float timeIntervalMin = 1f;
    [Tooltip ("Limite superior do intervalo de tempo entre spawns.")]
    [SerializeField] float timeIntervalMax = 5f;
    [Tooltip ("Lista de inimigos que serão spawnados por esse spawn point.")]
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();
    [Tooltip("Referência para o outro spawn point correspondente a esse na outra layer.")]
    [SerializeField] private EnemySpawner otherSpawner;

    //[HideInInspector]
    public bool canSpawn = false;

    private int myLayer;
    private GameManager gameManager;

    public float TimeIntervalMax
    {
        get
        {
            return timeIntervalMax;
        }

        set
        {
            timeIntervalMax = value;
        }
    }

    public float TimeIntervalMin
    {
        get
        {
            return timeIntervalMin;
        }

        set
        {
            timeIntervalMin = value;
        }
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        myLayer = GetComponentInParent<LayerBehaviour>().GetLayer();

        if (myLayer == 0)
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        float waitTime;
        int n;

        waitTime = Random.Range(timeIntervalMin, timeIntervalMax);
        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (canSpawn)
            {
                n = Random.Range(0, objectsToSpawn.Count);

                GameObject instance = Instantiate(objectsToSpawn[n], transform.position, objectsToSpawn[n].transform.rotation, transform);

                if (myLayer == 0)
                {
                    SpriteRenderer[] sprites = instance.GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer sprite in sprites)
                    {
                        sprite.sortingOrder += 1000;
                    }
                }

                if (myLayer == 0 && gameManager.GetCurrentLayer() != 0)
                {
                    // Transparente
                    MakeSpritesTransparent(instance);
                }
                else if (myLayer == 1 && gameManager.GetCurrentLayer() != 1)
                {
                    // Sombroso (futuro mudar)
                    MakeSpritesTransparent(instance);
                }

                waitTime = Random.Range(timeIntervalMin, timeIntervalMax);
                yield return new WaitForSeconds(waitTime);

                canSpawn = false;
                if (otherSpawner != null) otherSpawner.canSpawn = true;
            }
        }
    }

    private void MakeSpritesTransparent(GameObject instance)
    {
        SpriteRenderer[] sprites = instance.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            if (sprite != null) sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
        }
        Collider2D[] colliders = instance.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            if (collider != null) collider.enabled = false;
        }
    }
}
