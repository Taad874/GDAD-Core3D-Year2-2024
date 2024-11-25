using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables

     [HideInInspector]public float horizontalInput;
     [HideInInspector] public float verticalInput;
     [HideInInspector] public float speed;

    public float walkSpeed, runSpeed;
    

    public float maxStamina, runCost;
     public float stamina;
    [HideInInspector] public bool coolDown;
    [HideInInspector] public bool isRunning;

    [HideInInspector] public bool grounded;
    public float rotSpeed;
    public Quaternion newResetAngle;
    public Camera cam;


    [HideInInspector] public bool isMoving()
    {
        return horizontalInput != 0 || verticalInput != 0;
    }
    


   
    
    public void Move()
    {
        
       
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(-Vector3.right * Time.deltaTime * -horizontalInput * speed);

        
    }
    public void Running()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isRunning = Input.GetButton("Fire3") && stamina > 0 && isMoving() && !coolDown;


        speed = isRunning ? runSpeed : walkSpeed;
        if (isRunning)
        {
            stamina -= runCost * Time.deltaTime;
        }
        else
        {
            stamina += runCost * Time.deltaTime;
        }
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }
}
