using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed;

    public bool canJump = true;
    public float jumpHeight = 2.0f;
    //[SerializeField] private float turnSpeed = 0.5f;
    [SerializeField] private float walkSpeed, runSpeed;

    [SerializeField] private bool grounded = false;
    Rigidbody r;

    private bool isMoving;

    private bool onBall;
    [SerializeField] GameObject ballObject;
    [SerializeField] private Vector3 ballOffset;

    [SerializeField] private float maxStamina , runCost;
    private float stamina;
    private bool coolDown;



    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        stamina = maxStamina;
        //r.useGravity = false;
        //r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
       

    }

    private void FixedUpdate()
    {
        if (onBall)// && !isMoving)
        {
            //transform.parent = ballObject.transform;
            //transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + ballOffset, speed);

            ballObject.transform.rotation = transform.rotation;
            walkSpeed = 2f;
            runSpeed = 3.2f;
            ballObject.GetComponent<BallRolling>().enabled = true;
            // ballOffset = new Vector3(horizontalInput * speed, ballOffset.y, verticalInput * speed);
        }
        else
        {
            walkSpeed = 5f;
            runSpeed = 7f;
            ballObject.GetComponent<BallRolling>().enabled = false;

        }

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(-Vector3.right * Time.deltaTime * -horizontalInput * speed);

        if (!isMoving && onBall)
        {
            transform.position = Vector3.MoveTowards(transform.position, ballObject.transform.position + ballOffset, Time.deltaTime * speed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        bool isRunning = Input.GetButton("Fire3") && stamina > 0 && isMoving && !coolDown ;
        speed = isRunning ? runSpeed : walkSpeed;

        if (isRunning)
        {
            stamina -= runCost * Time.deltaTime;
        }
        else
        {
            if (stamina <= 0)
            {
                StartCoroutine("CoolDown");
            }
            stamina += runCost * Time.deltaTime;
        }
        if (grounded)
        {
            if (Input.GetButton("Jump") && canJump)
            {
                r.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
            }
        }
        if (!grounded) { canJump = false; }
        //if (!onBall)
        //{
        
            
            //transform.Rotate(Vector3.up * horizontalInput * turnSpeed); // * Time.deltaTime);
        //}
        
        if (horizontalInput != 0 || verticalInput != 0 || !grounded)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        stamina = Mathf.Clamp(stamina, 0, maxStamina);


        


    }
    private void OnTriggerEnter(Collider collision)
    {
        grounded = true;
        canJump = true;

        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = true;
            ballObject = collision.gameObject;
            transform.position = Vector3.MoveTowards(transform.position, ballObject.transform.position + ballOffset, Time.deltaTime * speed);
            //r.velocity = Vector3.zero;




        }
    }
    private void OnTriggerExit(Collider collision)
    {
        grounded = false;
        canJump = false;
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = false;
            //ballObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            

        }
    }
 
    // Stamina functions go here:
    public float GetStamina() => stamina;
    public float GetMaxStamina() => maxStamina;
    IEnumerator CoolDown()
    {
        coolDown = true;
        yield return new WaitForSeconds(maxStamina / runCost);
        coolDown = false;
    }
}
