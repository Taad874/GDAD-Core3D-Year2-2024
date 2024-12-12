using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] private FadeOut fade;
    private bool end;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            fade.fadeIn = true;
            end = true;
        }
    }
    private void Update()
    {
        if (fade.GetComponent<CanvasGroup>().alpha >= 1f && end == true)
        {
            SceneManager.LoadScene("EndingScene");
        }
        //if (end && Input.anyKeyDown)
        //{
        //    SceneManager.LoadScene("A-Maze-ing_Roll_1");
        //}
    }
}
