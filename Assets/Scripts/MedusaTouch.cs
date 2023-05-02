using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaTouch : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "roundedCubeItem")
        {
            other.gameObject.GetComponent<Renderer>().material.color = _renderer.material.color;
        }

        if (other.gameObject.tag == "eggItem")
        {
            other.gameObject.GetComponent<Renderer>().material.color = _renderer.material.color;
        }

        if (other.gameObject.tag == "ballItem")
        {
            other.gameObject.GetComponent<Renderer>().material.color = _renderer.material.color;
        }
    }
}
