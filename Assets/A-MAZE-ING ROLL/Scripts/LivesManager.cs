using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private LayerMask deathLayer;
    [SerializeField] private CheckPointSystem checkPoint;
    [SerializeField] private FadeOut fade;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private Vector3 deathCheck;
    private bool floorDeath;
    private bool holeDeath;
    private bool isDead;

    private void Awake()
    {
        DecreaseLives();
    }
    private void Update()
    {
        
        DecreaseLives();
        lives = Mathf.Clamp(lives, 0, 3);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                floorDeath = true;
                isDead = true;
                Death();
                holeDeath = false;
                Debug.Log(collision.gameObject.name);



            }
            else if (collision.gameObject.CompareTag("Hole"))
            {
                holeDeath = true;
                isDead = true;
                Death();
                floorDeath = false;
                Debug.Log(collision.gameObject.name);


            }

        }
    }

    
    private void Death()
    {
        
        playerMovement.enabled = false;
        if (lives <= 0)
        {
            lives = 0;
        }
        else { lives--; }
        DecreaseLives();
        //FadeOut
        
        //Respawn Goes Here
        
        StartCoroutine(FadeOut());
        
        
    }
    private void DecreaseLives()
    {
        livesText.text = "Lives:" + lives.ToString();
    }

    IEnumerator FadeOut()
    {
        fade.fadeIn = true;
        
        
        if (lives <= 0)
        {
            yield return new WaitForSeconds(1f);
            if (floorDeath)
            {

                Debug.Log("DiedFloor");
                //FloorDeath Cutscene
                SceneManager.LoadScene("FloorDeath");
            }
            else if (holeDeath)
            {
                Debug.Log("DiedHole");
                //HoleDEATH cutscene
                SceneManager.LoadScene("HoleDeath");
            }


        }
        else
        {
            
            audioSource.PlayOneShot(audioSource.clip);
            yield return new WaitForSeconds(1f);
            
            checkPoint.Spawning();
            yield return new WaitForSeconds(1f);
            fade.fadeOut = true;
            playerMovement.enabled = true;
            isDead = false;
        }
       


    }
   
}

    

