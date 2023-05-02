using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DuplicateObject : MonoBehaviour
{
    public InputActionReference _cloneReference;
    void Awake()
    {
        // add Cloned and Detached events to action's .started and .canceled states
        _cloneReference.action.started += Cloned;
        _cloneReference.action.canceled += Detached;
    }

    void Start()
    {
        
    }

    private void Cloned(InputAction.CallbackContext context)
    {
        // if the object is selected
        // instantiate a copy of the current gameObject in the current position/rotation

        if(gameObject.GetComponent<XRGrabInteractable>().isSelected)
        {
            Color currentColor = gameObject.GetComponent<HighlightObject>().GetOriginalColor();
            GameObject clonedObject = Instantiate(gameObject, transform.position, transform.rotation);

            clonedObject.GetComponent<MeshRenderer>().material.color = currentColor;
            // clonedObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        
        // can specify custom behaviors for the clone here
        // can do additional things like playing an sfx
    }

    private void Detached(InputAction.CallbackContext context)
    {
        // can specify custom behaviors for the original object when detached
    }
}
