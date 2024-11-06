using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
   
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    [SerializeField] private float turnSpeed = 0.5f;
    [SerializeField] private float speed = 5f;

    [SerializeField] private bool grounded = false;
    Rigidbody r;

    private bool isMoving;

    private bool onBall;
    [SerializeField] GameObject ballObject;
    [SerializeField] private Vector3 ballOffset;




    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        //r.useGravity = false;
        //r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (onBall)// && !isMoving)
        {
            transform.parent = ballObject.transform;
            transform.position = ballObject.transform.position + ballOffset;
            
            //ballObject.transform.rotation = transform.rotation;
            
            ballObject.GetComponent<BallRolling>().enabled = true;
            ballOffset = new Vector3(horizontalInput * speed, ballOffset.y, verticalInput * speed);
        }
        else
        {
            transform.parent = null;
            ballObject.GetComponent<BallRolling>().enabled = false;
            ballOffset = new Vector3(0,ballOffset.y, 0);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
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
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
            //transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput);
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed); // * Time.deltaTime);
        //}
        
        if (horizontalInput > 0 || verticalInput >0 || !grounded)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        






    }
    private void OnTriggerEnter(Collider collision)
    {
        grounded = true;
        canJump = true;

        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = true;
            ballObject = collision.gameObject;

            

            
            speed = .5f;

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        grounded = false;
        canJump = false;
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = false;
            speed = 5f;

        }
    }
    
    
    
}
