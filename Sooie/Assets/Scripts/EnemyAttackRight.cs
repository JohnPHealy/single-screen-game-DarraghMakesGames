using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackRight : MonoBehaviour
{

    [SerializeField] private UnityEvent RightHit;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("Player collided right");
            RightHit.Invoke();
        }

    }


}
