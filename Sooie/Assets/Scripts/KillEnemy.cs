using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillEnemy : MonoBehaviour
{

    [SerializeField] private UnityEvent killEnemy;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            print("Player jumped on enemy");
            killEnemy.Invoke();
            Destroy(transform.parent.gameObject);
        }

    }


}
