using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeCutter : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        // playerInputActions.Player.Cut.performed += Cut;
    }


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Link"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
