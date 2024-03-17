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
        RaycastHit2D hitInMobile = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue()), Vector2.zero);
        if (hitInMobile.collider != null)
        {
            if (hitInMobile.collider.CompareTag("Link"))
            {
                Destroy(hitInMobile.collider.gameObject);
            }
        }

        /*
        // For PC
        RaycastHit2D hitInPC = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
        if (hitInPC.collider != null)
        {
            if (hitInPC.collider.CompareTag("Link"))
            {
                Destroy(hitInPC.collider.gameObject);
            }
        }
        
        */
    }
}
