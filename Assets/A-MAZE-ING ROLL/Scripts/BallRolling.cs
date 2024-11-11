using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    public Audio_Behaviour audioBehaviour;
    private float moveHorizontal;
    private float moveVertical;
    private float speed;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float walkSpeed, runSpeed;
    [SerializeField] private float turnSpeed;

    private bool playerOn;
    private Rigidbody rb;
    [SerializeField] private GameObject playerObject;

    [SerializeField] private float maxStamina, runCost;
    private float stamina;
    [SerializeField] private float ejectForce;

    private bool isMoving;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioBehaviour = GetComponent<Audio_Behaviour>();
        stamina = maxStamina;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveVertical * speed);
        transform.Translate(-Vector3.right * Time.deltaTime * -moveHorizontal * speed);
    }
    // Update is called once per frame
    void Update()
    {
        //if (playerOn)
        //{
        //    playerObject.transform.position = transform.position + offset; 
        //}
        bool isRunning = Input.GetButton("Fire3") && stamina > 0 && isMoving;
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        speed = isRunning ?  runSpeed : walkSpeed;

        //transform.Rotate(Vector3.up * moveHorizontal * turnSpeed); // * Time.deltaTime);


        if (isRunning)
        {
            
            stamina -= runCost * Time.deltaTime;
        }
        else
        {
            
            stamina += runCost * Time.deltaTime;
        }

        if (stamina == 0)
        {
            playerObject.GetComponent<Rigidbody>().AddForce(new Vector3(ejectForce, ejectForce, ejectForce), ForceMode.Force);
            stamina = maxStamina;
        }
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            
            isMoving = true;
            AudioEventManager.PlaySFX(this.transform, "Ball2", 1.0f, 1.0f, true, 0.1f, 0f);
        }
        else
        {
            isMoving = false;
            //audioBehaviour.EndClip();
        }

        
            
        
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }
}
