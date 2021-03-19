using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitDoorPrompt : MonoBehaviour
{

    [SerializeField] private UnityEvent ExitPromptEnter;
    [SerializeField] private UnityEvent ExitPromptExit;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExitPromptEnter.Invoke();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ExitPromptExit.Invoke();
        }
    }


}
