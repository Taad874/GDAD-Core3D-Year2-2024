using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    private bool end;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            canvasGroup.alpha = 1;
            other.GetComponent<PlayerMovement>().enabled = false;
            end = true;
        }
    }
    private void Update()
    {
        if (end && Input.anyKeyDown)
        {
            SceneManager.LoadScene("A-Maze-ing_Roll_1");
        }
    }
}
