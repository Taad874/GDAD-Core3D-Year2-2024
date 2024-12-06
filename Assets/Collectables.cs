using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private int items;
    [SerializeField] private TextMeshProUGUI collectablesText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip silverClip;
    [SerializeField] private AudioClip rubyClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseCollectibles();
    }
    private void IncreaseCollectibles()
    {
        collectablesText.text = "Monkeys:" + items.ToString();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("SilverMonkey"))
        {
            items++;
            Destroy(collision.gameObject);
            audioSource.pitch = Random.Range(1f, 1.5f);
            audioSource.volume = 1f;
            audioSource.PlayOneShot(silverClip);
            
        }
        if (collision.CompareTag("RubyMonkey"))
        {
            items += 2;
            Destroy(collision.gameObject);
            audioSource.pitch = Random.Range(0.7f, 1.5f);
            audioSource.volume = 1f;
            audioSource.PlayOneShot(rubyClip);
            

        }
    }
   
}
