using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSoundManager : MonoBehaviour
{

    //public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySound(AudioClip _clip, float _volume = 1f, bool looped = false, float _pitch = 1.0f, float _delay = 0.0f)
    {
        audioSrc.clip = _clip;
        audioSrc.loop = looped;
        audioSrc.pitch = _pitch;
        audioSrc.volume = _volume;
        if (_delay > 0) { audioSrc.PlayDelayed(_delay); }
        else { audioSrc.PlayOneShot(_clip); }
    }
    
    public void StopSound()
    {
        audioSrc.Stop();
    }

}//public class CSoundTest : MonoBehaviour
