using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveForce, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers, platformLayers1, platformLayers2, platformLayers3;
    [SerializeField] private GameObject playerAnimator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject platform1, platform2, platform3;
    private float moveDirection;
    private Rigidbody2D playerRB;

    

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



        //Platform movement fix

        if (groundCheck.IsTouchingLayers(platformLayers1))
        {
            transform.parent = platform1.transform;
        }
        else if (groundCheck.IsTouchingLayers(platformLayers2))
        {
            transform.parent = platform2.transform;
        }
        else if (groundCheck.IsTouchingLayers(platformLayers3))
        {
            transform.parent = platform3.transform;
        }
        else
        {
            transform.parent = null;
        }


    }



    public void Move(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<float>());
        moveDirection = context.ReadValue<float>();
    }

    public void Move(float moveAmount)
    {
        //print(context.ReadValue<float>());
        moveDirection = moveAmount;
    }

 








}
