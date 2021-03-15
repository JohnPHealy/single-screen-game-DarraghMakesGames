using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private UnityEvent triggered;
    private Collider2D interactableCollider;

    private void Start()
    {
        interactableCollider = GetComponent<Collider2D>();
    }

    public void PlayerInteract(InputAction.CallbackContext context)
    {
        if(context.ReadValue<float>() >= 0.5f)
        {
            if (interactableCollider.IsTouchingLayers(playerLayer))
            {
                triggered.Invoke();
            }
        }
    }

}
