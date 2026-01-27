using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundstart : MonoBehaviour
{
    public AudioSource Sound;
    private bool isPlaying = false;
    public void Soundcall()
    {
        if (!isPlaying)
        {
            
            Sound.Play();
            isPlaying = true;
            
        }
    }
    
}
