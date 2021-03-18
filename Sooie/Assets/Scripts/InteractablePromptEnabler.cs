using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractablePromptEnabler : MonoBehaviour
{
    [SerializeField] private UnityEvent ButtonsOn;
    [SerializeField] private UnityEvent ButtonsOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ButtonsOn.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ButtonsOff.Invoke();
        }
            
    }



}

    


