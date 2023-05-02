using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyObject : MonoBehaviour
{
        AudioSource _audioSource;
        public AudioClip clip;
        public InputActionReference _deleteReference;
        public GameObject particles;

        void Awake()
        {
            // add Cloned and Detached events to action's .started and .canceled states
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.clip = clip;
            _deleteReference.action.started += Destroyed;
            _deleteReference.action.canceled += Detached;
        }

        private void Destroyed(InputAction.CallbackContext context)
        {
            if (gameObject.GetComponent<XRGrabInteractable>().isSelected)
            {
                GameObject particleClone = Instantiate(particles, transform.position, transform.rotation);

                if (_audioSource.clip)
                {
                    _audioSource.Play();
                }

                Destroy(particleClone.gameObject, 0.4f);

                Destroy(gameObject, 0.4f);
            }
        }

        private void Detached(InputAction.CallbackContext context)
        {
            // can specify custom behaviors for the original object when detached
        }

}
