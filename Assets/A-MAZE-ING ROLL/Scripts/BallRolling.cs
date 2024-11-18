using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallRolling : Movement
{
    //public Audio_Behaviour audioBehaviour;

    private Rigidbody rb;
    [SerializeField] private GameObject playerObject;

    
    [SerializeField] private float ejectForce;

    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //audioBehaviour = GetComponent<Audio_Behaviour>();
        stamina = maxStamina;
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {

        Running();

        if (stamina == 0)
        {
            playerObject.GetComponent<Rigidbody>().AddForce(new Vector3(ejectForce, ejectForce, ejectForce), ForceMode.Force);
            stamina = maxStamina;
        }
        if (isMoving())
        {
            AudioEventManager.PlaySFX(this.transform, "Ball2", 1.0f, 1.0f, true, 0.1f, 0f, "Moving");
        }
        
    }
}
