using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float walkSpeed, runSpeed;
    [SerializeField] private float turnSpeed;

    private bool playerOn;
    private Rigidbody rb;
    [SerializeField] private GameObject playerObject;

    [SerializeField] private float maxStamina, runCost;
    private float stamina;

    private bool isMoving;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerOn)
        //{
        //    playerObject.transform.position = transform.position + offset; 
        //}
        bool isRunning = Input.GetButton("Fire3") && stamina > 0 && isMoving;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float speed = isRunning ?  runSpeed : walkSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * moveVertical * speed);
        transform.Translate(-Vector3.right * Time.deltaTime * -moveHorizontal * speed);
        //transform.Rotate(Vector3.up * moveHorizontal * turnSpeed); // * Time.deltaTime);


        if (isRunning)
        {
            stamina -= runCost * Time.deltaTime;
        }
        else
        {
            
            stamina += runCost * Time.deltaTime;
        }

        if (stamina <= 0)
        {
            playerObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,3,0), ForceMode.VelocityChange);
        }
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }
}
