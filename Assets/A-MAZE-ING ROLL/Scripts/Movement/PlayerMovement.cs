using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : Movement
{

    private bool falling;
    private bool canJump = true;
    public float jumpHeight = 2.0f;
    
    Rigidbody r;

    private bool onBall;
    [SerializeField] GameObject ballObject;
    [SerializeField] private Vector3 ballOffset;
    
    private Animator animator;
   
    


    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        maxStamina = 100f;
        runCost = 10f;
        stamina = maxStamina;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            newResetAngle = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, newResetAngle, rotSpeed * Time.deltaTime).normalized;
        }
        Move();
        if (onBall)// && !isMoving)
        {

            //ballObject.transform.rotation = transform.rotation;
            walkSpeed = 2f;
            runSpeed = 3.2f;
            ballObject.GetComponent<BallRolling>().enabled = true;
            
        }
        else
        {
            walkSpeed = 5f;
            runSpeed = 7f;
            ballObject.GetComponent<BallRolling>().enabled = false;
            animator.SetBool("ReCenter", false);
        }



        if (!isMoving() && onBall)
        {
            transform.position = Vector3.MoveTowards(transform.position, ballObject.transform.position + ballOffset, Time.deltaTime * speed);
            animator.SetBool("ReCenter", true);
            if (transform.position == ballObject.transform.position + ballOffset)
            {
                animator.SetBool("ReCenter", false);
            }

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Running();
        if (stamina <= 0)
            {
                StartCoroutine("CoolDown");
            }
        
        
        if (grounded)
        {
           
            falling = false;
            if (Input.GetButton("Jump") && canJump)
            {
               
                r.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
            }
        }
        if (!grounded) { canJump = false; falling = true;  }

        

        AnimationUpdate();
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
            ballObject.GetComponent<BallRolling>().stamina = ballObject.GetComponent<BallRolling>().maxStamina;




        }
    }
    private void OnTriggerExit(Collider collision)
    {
        grounded = false;
        canJump = false;
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBall = false;
            

        }
    }
 
   
    public float GetStamina() => stamina;
    public float GetMaxStamina() => maxStamina;
    IEnumerator CoolDown()
    {
        coolDown = true;
        yield return new WaitForSeconds(maxStamina / runCost);
        coolDown = false;
    }
    private void AnimationUpdate()
    {
        animator.SetFloat("Speed", speed);
        animator.SetFloat("MotionSpeed", verticalInput);
        animator.SetFloat("HorizontalSpeed", horizontalInput);
        animator.SetBool("IsMoving", isMoving());
        animator.SetBool("Jump", Input.GetButton("Jump"));
        animator.SetBool("Grounded", grounded);
        animator.SetBool("FreeFall", falling);
        animator.SetBool("Vertical", verticalInput != 0);
        animator.SetBool("Horizontal", horizontalInput != 0);
    }
}
