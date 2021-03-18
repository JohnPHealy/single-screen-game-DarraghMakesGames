using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] public float moveDir;
    [SerializeField] private UnityEvent moveLeft;
    [SerializeField] private float maxSpeed;
    private SpriteRenderer pigSprite;
    private Rigidbody2D pigRB;

    // Start is called before the first frame update
    void Start()
    {
        pigRB = GetComponent<Rigidbody2D>();
        moveDir = 1f;
        pigSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()

    {
        if (Mathf.Abs(pigRB.velocity.x) < maxSpeed)
        {
            pigRB.AddForce(transform.right * moveDir);
        }

        if(pigRB.velocity.x < 1)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if(pigRB.velocity.x > 0.1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        }

    public void LeftMovement()
    {
        moveDir = -1f;
    }
    public void RightMovement()
    {
        moveDir = 1f;
    }

}
