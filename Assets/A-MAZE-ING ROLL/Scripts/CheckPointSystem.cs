using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] checkPoints;
    //[SerializeField] private LayerMask checkPointLay;
    private int currentCheckPoint;

    private void Awake()
    {
        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        currentCheckPoint = 0;
        Debug.Log(checkPoints[currentCheckPoint].name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
