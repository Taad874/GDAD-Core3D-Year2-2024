using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private LayerMask deathLayer;
    [SerializeField] private CheckPointSystem checkPoint;
    [SerializeField] private FadeOut fade;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TextMeshProUGUI livesText;
    private bool floorDeath;
    private bool holeDeath;

    private void Awake()
    {
        DecreaseLives();
    }
    private void Update()
    {
        if (lives <= 0)
        {
            if (floorDeath)
            {
                //FloorDeath Cutscene
            }
            else if (holeDeath)
            {
                //HoleDEATH cutscene
            }


        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == deathLayer) //LOOK UP ABOUT LAYERMASKS (Hint: It is used in Update when doing it for Corto :3)
        {
            


        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            floorDeath = true;
            Debug.Log(collision.gameObject.name);
            Debug.Log("Died");
            //playerMovement.enabled = false;
            lives--;
            DecreaseLives();
            //FadeOut
            fade.fadeIn = true;

            //Respawn Goes Here
            checkPoint.Spawning();
           
            holeDeath = false;
            StartCoroutine(FadeOut());
        }
        else if (collision.gameObject.CompareTag("Hole"))
        {
            holeDeath = true;
            Debug.Log(collision.gameObject.name);
            Debug.Log("Died");
            //playerMovement.enabled = false;
            lives--;
            DecreaseLives();
            //FadeOut
            fade.fadeIn = true;

            //Respawn Goes Here
            checkPoint.Spawning();
            floorDeath = false;
            
            StartCoroutine(FadeOut());
        }

    
    }

        
    void DecreaseLives()
    {
        livesText.text = "Lives:" + lives.ToString();
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);
        fade.fadeOut = true;
        yield return new WaitForSeconds(1f);
        playerMovement.enabled = true;
    }
}

    

