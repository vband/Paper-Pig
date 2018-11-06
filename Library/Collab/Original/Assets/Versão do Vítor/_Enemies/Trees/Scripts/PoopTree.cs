using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopTree : Enemy
{

    [Tooltip("Limite inferior do intervalo de tempo entre cagadas.")]
    [Range(1f, 5f)]
    [SerializeField] float timeIntervalMin = 1f;
    [Tooltip("Limite superior do intervalo de tempo entre cagadas.")]
    [Range(1f, 5f)]
    [SerializeField] float timeIntervalMax = 5f;
    [Tooltip("Prefab do cocô.")]
    [SerializeField] private GameObject poop;
    [Tooltip("Velocidade de queda inicial do cocô.")]
    [SerializeField] private float poopSpeed = 5f;

    private GameManager gameManager;
    private int myLayer;

    private new void Start()
    {
        base.Start();

        gameManager = FindObjectOfType<GameManager>();
        myLayer = GetComponentInParent<LayerBehaviour>().GetLayer();

        StartCoroutine("Poop");
    }

    private IEnumerator Poop()
    {
        float waitTime;

        while (true)
        {
            waitTime = Random.Range(timeIntervalMin, timeIntervalMax);

            yield return new WaitForSeconds(waitTime);
            GameObject instance = Instantiate(poop, transform.position + poop.transform.localPosition, poop.transform.rotation, transform);

            if (instance.GetComponent<Rigidbody2D>()) instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -poopSpeed);

            if (myLayer == 0 && gameManager.GetCurrentLayer() != 0)
            {
                // Transparente
                SpriteRenderer sprite = instance.GetComponent<SpriteRenderer>();
                if (sprite != null) sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
                Collider2D collider = instance.GetComponent<Collider2D>();
                if (collider != null) collider.enabled = false;
            }
            else if (myLayer == 1 && gameManager.GetCurrentLayer() != 1)
            {
                // Opaco
                SpriteRenderer sprite = instance.GetComponent<SpriteRenderer>();
                if (sprite != null) sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
                Collider2D collider = instance.GetComponent<Collider2D>();
                if (collider != null) collider.enabled = false;
            }
        }
    }
}
