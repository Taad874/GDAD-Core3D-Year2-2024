using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallRolling : Movement
{
    //public Audio_Behaviour audioBehaviour;

    private Rigidbody rb;
    [SerializeField] private GameObject playerObject;
    
    
    public float ejectForce;

    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //audioBehaviour = GetComponent<Audio_Behaviour>();
        stamina = maxStamina;
        
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            newResetAngle = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, newResetAngle, rotSpeed * Time.deltaTime).normalized;
        }
        Move();
        
        
    }
    // Update is called once per frame
    void Update()
    {

        Running();

        if (stamina == 0)
        {
            Debug.Log("Ejection?");
            playerObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, ejectForce, 0), ForceMode.Force);
            //stamina = maxStamina;
        }
        if (isMoving())
        {
            AudioEventManager.PlaySFX(this.transform, "Ball2", 1.0f, 1.0f, true, 0.1f, 0f, "Moving");
        }
        
    }
    
}
