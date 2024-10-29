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
    private GameObject ballObject;
    [SerializeField] private Vector3 ballOffset;




    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        //r.useGravity = false;
        r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (onBall && !isMoving)
        {
            transform.position = ballObject.transform.position + ballOffset;
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
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        //transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed); // * Time.deltaTime);
        if (horizontalInput > 0 || verticalInput >0 || !grounded)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }



//Swap the snap around from ball to player
//Make ball move similar to player but slightly slower

        
    }
    private void OnTriggerEnter(Collider other)
    {
        grounded = true;
        canJump = true;
    }
    private void OnTriggerExit(Collider other)
    {
        grounded = false;
        canJump = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = true;
            ballObject = collision.gameObject;
            ballObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.position = ballObject.transform.position + ballOffset;
            speed = .5f;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = false;
            speed = 5f;
            ballObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
