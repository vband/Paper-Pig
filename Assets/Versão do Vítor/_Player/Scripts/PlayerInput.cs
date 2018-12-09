using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
#if UNITY_STANDALONE_WIN
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode changeLayerKey = KeyCode.V;
#endif

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

#if UNITY_STANDALONE_WIN
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
#endif

#if UNITY_ANDROID
    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 2)
        {
            playerMovement.Fly();
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x >= Screen.width/2)
        {
            playerMovement.ChangeLayer();
        }
    }
#endif
}
