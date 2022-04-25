using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] songlist;
    public AudioSource audioSource;
    private void Start()
    {
        int nextSong = Random.Range(0, 5);
        audioSource.clip = songlist[nextSong];
        audioSource.Play();
    }
    void Update()
    { 
        if (audioSource.time == audioSource.clip.length)
        {
            Debug.Log(audioSource.clip);
            audioSource.Stop();
            audioSource.time = 0;
            int nextSong = Random.Range(0, 5);
            audioSource.clip = songlist[nextSong];
            audioSource.Play();

        }
        else
        {
            return;
        }
    }
}
