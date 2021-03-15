using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers;
    private float moveDirection;
    private Rigidbody2D playerRB;
    private bool canJump;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(playerRB.velocity.x) < maxSpeed)
        {
            var moveAxis = Vector2.right * moveDirection;
            playerRB.AddForce(moveAxis * moveForce, ForceMode2D.Force);
        }

        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<float>());
        moveDirection = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<float>());
        if (canJump && context.started)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //canJump = false;
        }

        if (context.canceled && playerRB.velocity.y > 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
        }

    }

}
