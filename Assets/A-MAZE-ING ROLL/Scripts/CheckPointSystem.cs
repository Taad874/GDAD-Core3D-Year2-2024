using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private Transform ball;
    //Do checkpoints for ball
    
    
    public void Spawning() 
    {
        Debug.Log($"Spawning");
        ball.position = ballSpawnPoint.position;
        transform.position = spawnPoint.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            spawnPoint.position = other.transform.position; //setting the player spawn to the checkPoint position
            ballSpawnPoint.position = other.transform.GetChild(0).position; //GetChild sets the ballSpawn to the child transform
            //Stops checkpoints from being lost if player backtracks
            other.gameObject.SetActive(false);
        }
    }
}
