using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode changeLayerKey = KeyCode.V;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(jumpKey))
        {
            playerMovement.Fly();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(changeLayerKey))
        {
            playerMovement.ChangeLayer();
        }
    }
}
