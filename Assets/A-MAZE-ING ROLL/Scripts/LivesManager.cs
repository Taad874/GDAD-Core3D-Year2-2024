using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private LayerMask deathLayer;
    [SerializeField] private CheckPointSystem checkPoint;
    private bool floorDeath;
    private bool holeDeath;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == deathLayer)
        {
            

            lives--;
            //FadeOut
            StartCoroutine(FadeOut());
            //Respawn Goes Here
            checkPoint.Spawning();
            floorDeath = false;
            holeDeath = false;
            
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            floorDeath = true;
        }
        else if (collision.gameObject.CompareTag("Hole"))
        {
            holeDeath = true;
        }
           
        IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(1f);
        }
    }

    

}
