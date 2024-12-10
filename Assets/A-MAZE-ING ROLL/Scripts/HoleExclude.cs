using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleExclude : MonoBehaviour
{
    
    [SerializeField] private LayerMask excludeMask1;
    [SerializeField] private LayerMask excludeMask2;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.GetComponent<Rigidbody>().excludeLayers = excludeMask1;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.GetComponent<Rigidbody>().excludeLayers = excludeMask2;
        }
    }
}
