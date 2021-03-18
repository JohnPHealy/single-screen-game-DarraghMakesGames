using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitialCameraTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent InitialCameraTrig;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            InitialCameraTrig.Invoke();
        }
    }


}
