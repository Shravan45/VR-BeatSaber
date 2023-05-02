using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// to be attached to the controller for which you want to toggle RayInteractor
/// switches between RayInteractor and DirectInteractor
/// </summary>
public class ToggleRay : MonoBehaviour
{
    // define a public InputActionReference for toggle button
    // and a reference to the rayInteractor GameObject to be toggled

    // need a global variable for the XRDirectInteractor reference
    public InputActionReference toggleReference;

    public GameObject ray_interactor;

    XRDirectInteractor _directInteractor;
    void Awake()
    {
        // add Pressed and Released events to action's .started and .canceled states
        // get a reference to the XRDirectInteractor attached to current gameObject
        toggleReference.action.started += Pressed;

        toggleReference.action.canceled += Released;

        _directInteractor = GetComponent<XRDirectInteractor>();
        // ray_interactor = GetComponent<XRRayInteractor>();
        
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        
    }

    void Pressed(InputAction.CallbackContext context)
    {
        Toggle();
    }

    void Released(InputAction.CallbackContext context)
    {
        Toggle();
    }

    void Toggle()
    {
        // get a bool, isToggled, for the current state of the rayInteractor
        // setActive of the rayInteractor based on the bool value
        // set enable of the directInteractor based on the bool value

        bool isToggled = ray_interactor.activeSelf;

        if(!isToggled)
        {
            _directInteractor.enabled = false;
            ray_interactor.SetActive(true);
        }
        else
        {
            _directInteractor.enabled = true;
            ray_interactor.SetActive(false);
        }
    }
}
