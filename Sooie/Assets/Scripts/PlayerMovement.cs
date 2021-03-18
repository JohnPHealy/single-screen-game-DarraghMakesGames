using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveForce, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private LayerMask groundLayers, platformLayers1, platformLayers2, platformLayers3;
    [SerializeField] private GameObject playerAnimator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject platform1, platform2, platform3;
    private float moveDirection;
    private Rigidbody2D playerRB;
    private bool canJump;
    private Animator anim;
    private float enemyHitForce = 10f;
    private int playerHealth = 3;
    

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        


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

    //If hit by enemy

    public void HitLeft()
    {
        playerRB.AddForce(transform.right * -enemyHitForce, ForceMode2D.Impulse);
    }

    public void HitRight()
    {
        playerRB.AddForce(transform.right * enemyHitForce, ForceMode2D.Impulse);
    }

    public void EnemyBounce()
    {
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    //End hit by enemy

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



    private void Update()
    {
        if(moveDirection < 0)
        {
            playerAnimator.transform.localScale = new Vector3(-1, playerAnimator.transform.localScale.y, playerAnimator.transform.localScale.z);
        }
        if (moveDirection > 0)
        {
            playerAnimator.transform.localScale = new Vector3(1, playerAnimator.transform.localScale.y, playerAnimator.transform.localScale.z);
        }

        moveSpeed = Mathf.Abs(playerRB.velocity.x);
        anim.SetFloat("MoveSpeed", moveSpeed);


        //Player death
        if (playerHealth < 1)
        {
            SceneManager.LoadScene("CastleExterior");
        }

    }

    //Player damage

    public void PlayerDamage()

    {
        playerHealth--;        
    }



}
