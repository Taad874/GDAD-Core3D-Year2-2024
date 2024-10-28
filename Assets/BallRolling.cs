using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRolling : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;
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
        if (playerOn)
        {
            playerObject.transform.position = transform.position + offset; 
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
            playerObject = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }
}
