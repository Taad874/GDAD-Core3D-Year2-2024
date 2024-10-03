using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// The ItemClick script allows interaction with items by clicking on them
public class ItemClick : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Check if the ray hits any collider in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Attempt to get the Item component from the hit object
                Item clickedItem = hit.transform.GetComponent<Item>();
                // If an Item component is found, interact with it
                if (clickedItem != null)
                {
                    // Call the DisplayInfo method of the clicked item
                    clickedItem.DisplayInfo();
                    // Call the SayHello method of the clicked item
                    clickedItem.SayHello();
                }
            }
        }
    }
}
