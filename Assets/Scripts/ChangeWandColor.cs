//using UnityEngine;
//using UnityEngine.InputSystem;

//public class ChangeWandColor : MonoBehaviour
//{
//    AudioSource _audioSource;
//    MeshRenderer _renderer;
//    Color originalColor;
//    public InputActionReference _colorSwitchReference;

//    public Color tipColorMagenta = Color.magenta;
//    public Color tipColorBlue = Color.blue;
//    public Color tipColorYellow = Color.yellow;
//    public Color tipColorRed = Color.red;

//    void Awake()
//    {
//        _renderer = GetComponent<MeshRenderer>();
//        _audioSource = GetComponent<AudioSource>();

//        originalColor = _renderer.material.color;
//        _colorSwitchReference.action.started += SwitchTipColor;
//    }


//    void SwitchTipColor(InputAction.CallbackContext context)
//    {
//        if (_colorSwitchReference.action.ReadValue<float>() > 0.0f)
//        {
//            _audioSource.Play();
//        }

//        if (_renderer.material.color == originalColor)
//        {
//            _renderer.material.color = tipColorMagenta;
//        }
//        else if (_renderer.material.color == tipColorMagenta)
//        {
//            _renderer.material.color = tipColorBlue;
//        }
//        else if (_renderer.material.color == tipColorBlue)
//        {
//            _renderer.material.color = tipColorYellow;
//        }
//        else if (_renderer.material.color == tipColorYellow)
//        {
//            _renderer.material.color = tipColorRed;
//        }
//        else
//        {
//            _renderer.material.color = originalColor;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeWandColor : MonoBehaviour
{

    AudioSource _audioSource;
    MeshRenderer _renderer;
    Color originalColor;

    public Color blue = Color.blue;
    public Color red = Color.red;
    public Color yellow = Color.yellow;
    public Color green = Color.green;

    public InputActionReference inputActionReference;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _renderer = GetComponent<MeshRenderer>();

        originalColor = _renderer.material.color;

        inputActionReference.action.performed += SwitchColor;
    }


    void SwitchColor(InputAction.CallbackContext context)
    {
        if (inputActionReference.action.ReadValue<float>() > 0.0f)
        {
            _audioSource.Play();
        }
        if (_renderer.material.color == originalColor)
        {
            _renderer.material.color = blue;
        }
        else if (_renderer.material.color == blue)
        {
            _renderer.material.color = red;
        }
        else if (_renderer.material.color == red)
        {
            _renderer.material.color = yellow;
        }
        else if (_renderer.material.color == yellow)
        {
            _renderer.material.color = green;
        }
        else
        {
            _renderer.material.color = originalColor;
        }
    }
}