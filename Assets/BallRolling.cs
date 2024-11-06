using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private bool playerOn;
    private Rigidbody rb;
    private GameObject playerObject;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerOn)
        //{
        //    playerObject.transform.position = transform.position + offset; 
        //}
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * moveVertical * speed);
        //transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up * moveHorizontal * turnSpeed); // * Time.deltaTime);
    }
}
