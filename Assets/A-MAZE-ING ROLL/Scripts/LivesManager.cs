using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private LayerMask deathLayer;
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
            //Respawn Goes Here
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            floorDeath = true;
        }
           
        
    }

    

}
