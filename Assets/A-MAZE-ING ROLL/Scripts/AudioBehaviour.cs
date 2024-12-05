using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class Audio_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] clips;
    public AudioSource source;
    

    public void PlayRandClip(int i)
    {
        source.clip = clips[i];
        source.volume = 0.1f;
        source.pitch = Random.Range(0.75f, 2f);
        source.Play();
        //source.enabled = true;
    }
    public void PlayClip(int i)
    {
        source.volume = 1f;
        source.clip = clips[i];
        source.pitch = 1f;
        source.Play();
        //source.enabled = true;
    }

    public void EndClip()
    {
        //source.enabled = false;
        source.Stop();
    }

}
