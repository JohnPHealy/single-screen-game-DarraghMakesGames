using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private UnityEvent<float> movement;
    [SerializeField] private float moveDirection = 1f;
    [SerializeField] private Transform patrolLeft, patrolRight;

    private void Update()
    {

        if(transform.position.x < patrolLeft.position.x)
        {
            moveDirection = 1f;
        }
        if (transform.position.x > patrolRight.position.x)
        {
            moveDirection = -1f;
        }

        movement.Invoke(moveDirection);

    }

}
