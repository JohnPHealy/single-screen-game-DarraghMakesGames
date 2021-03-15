using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;
    private float moveDirection;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }



    public void Move(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<float>());
        moveDirection = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<float>());
    }
    
}
