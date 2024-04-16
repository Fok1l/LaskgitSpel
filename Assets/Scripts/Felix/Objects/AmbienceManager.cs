using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    AudioClip m_AudioClip;
    AudioSource m_AudioSource;

    public void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
  
    IEnumerator waiter()
    {
        int wait_time = Random.Range(0, 1000);
        yield return new WaitForSeconds(wait_time);
        print("I waited for " + wait_time + "sec");
    }
}
