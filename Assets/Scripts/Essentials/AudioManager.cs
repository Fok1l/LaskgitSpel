using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public void PaperSound()
    {
        source.PlayOneShot(clip);
    }
}
