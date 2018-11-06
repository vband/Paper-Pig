using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent (typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float flyForce = 50f;
    [SerializeField] private float layerTransitionDuration = 0.3f;
    [SerializeField] private GameObject shadow;

    private Rigidbody2D rigidBody;
    private enum Layer { layer0, layer1 };
    private Layer layer = Layer.layer0;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        if (layer == Layer.layer0)
        {
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y, 5);
        }
        else if (layer == Layer.layer1)
        {
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    private void Update()
    {
        shadow.transform.position = new Vector3(transform.position.x, transform.position.y, shadow.transform.position.z);
    }

    public void Fly()
    {
        rigidBody.AddForce(Vector2.up * flyForce * Time.fixedDeltaTime);
    }

    public void ChangeLayer()
    {
        if (layer == Layer.layer0)
        {
            transform.DOMove(new Vector3(transform.position.x, transform.position.y, 5),
                             layerTransitionDuration);
            shadow.transform.DOMove(new Vector3(transform.position.x, transform.position.y, 0),
                              layerTransitionDuration);
            GetComponent<SpriteRenderer>().sortingOrder -= 1000;
            layer = Layer.layer1;
            gameManager.ChangeLayer(1);
        }
        else if (layer == Layer.layer1)
        {
            transform.DOMove(new Vector3(transform.position.x, transform.position.y, 0),
                             layerTransitionDuration);
            shadow.transform.DOMove(new Vector3(transform.position.x, transform.position.y, 5),
                              layerTransitionDuration);
            GetComponent<SpriteRenderer>().sortingOrder += 1000;
            layer = Layer.layer0;
            gameManager.ChangeLayer(0);
        }
    }
}
