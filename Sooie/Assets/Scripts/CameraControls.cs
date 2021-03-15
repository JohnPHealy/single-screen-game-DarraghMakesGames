using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class CameraControls : MonoBehaviour
{

    private bool cameraToggled;
    [SerializeField] UnityEvent camToggled;
    [SerializeField] UnityEvent camUntoggled;

    private void Start()
    {
        //cameraToggled = true;
    }

    public void cameraToggle(InputAction.CallbackContext context)
    {
        //print(context.ReadValue<float>());
        if (context.started)
        {
            print("Toggle");
            camToggled.Invoke();
            //cameraToggled = true;
        }

        if (context.canceled)
        {
            print("Untoggle");
            camUntoggled.Invoke();
            //cameraToggled = false;
        }

    }

    }
