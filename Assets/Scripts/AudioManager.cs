using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip sfxHit;
    [SerializeField] AudioClip sfxGoal;

    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();    
    }

    public void PlaySound(string otherTag) {
        if(otherTag == "Goal") {
            audioSource.PlayOneShot(sfxGoal);
        } else {
            audioSource.PlayOneShot(sfxHit);
        }
    }
}
