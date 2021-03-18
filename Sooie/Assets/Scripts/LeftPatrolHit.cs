using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeftPatrolHit : MonoBehaviour
{

    [SerializeField] private UnityEvent LeftHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            LeftHit.Invoke();
        }
    }

}
