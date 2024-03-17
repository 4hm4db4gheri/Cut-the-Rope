using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeCutter : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [SerializeField] private float distroyLinksDuration = 2f;

    Rope parentRope;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Cut.performed += Cut;
    }

    public void Cut(InputAction.CallbackContext context)
    {
        RaycastHit2D hitInMobile = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue()), Vector2.zero);
        if (hitInMobile.collider != null)
        {
            if (hitInMobile.collider.CompareTag("Link"))
            {
                parentRope = hitInMobile.transform.parent.GetComponent<Rope>();
                //checking is any link deleted or not
                if (!(parentRope.transform.childCount < parentRope.linkNumbers + 1))
                {
                    Destroy(hitInMobile.collider.gameObject);
                    for (int i = 1; i < parentRope.linkNumbers + 1; i++)
                    {
                        Destroy(parentRope.transform.GetChild(i).gameObject, distroyLinksDuration);
                    }
                }
            }
        }
    }


    // private void Update()
    // {
    //     RaycastHit2D hitInMobile = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue()), Vector2.zero);
    //     if (hitInMobile.collider != null)
    //     {
    //         if (hitInMobile.collider.CompareTag("Link"))
    //         {
    //             parentRope = hitInMobile.transform.parent.GetComponent<Rope>();
    //             Destroy(hitInMobile.collider.gameObject);
    //             for (int i = 1; i < parentRope.linkNumbers + 1; i++)
    //             {
    //                 Destroy(parentRope.transform.GetChild(i).gameObject, distroyLinksDuration);
    //                 Debug.Log(parentRope.transform.GetChild(i).gameObject);
    //             }
    //             // Destroy(hitInMobile.transform.parent.gameObject, 2f);
    //         }
    //     }

    //     /*
    //     // For PC
    //     RaycastHit2D hitInPC = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
    //     if (hitInPC.collider != null)
    //     {
    //         if (hitInPC.collider.CompareTag("Link"))
    //         {
    //             Destroy(hitInPC.collider.gameObject);
    //         }
    //     }

    //     */
    // }
}
