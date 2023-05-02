using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnCollision : MonoBehaviour
{
    AudioSource _audioSource;

    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = clip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_audioSource.clip)
        {
            _audioSource.Play();
        }
    }


}
