using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        
        soundSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
    }

    // Update is called once per frame
    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(1f);
       
        
        if (!soundSource.isPlaying) 
        {

            soundSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length )]);
            Debug.Log(audioClips.Length);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine(PlaySound());
    }
}
