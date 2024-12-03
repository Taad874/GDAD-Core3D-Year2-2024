using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector transition;
    private double transitionDuration;

    private bool isCutscene;


    private void Awake()
    {
        transition = transition.GetComponent<PlayableDirector>();
        transitionDuration = transition.GetComponent<PlayableDirector>().duration;
        
    }
   

    // Update is called once per frame
    void Update()
    {
        if (transition.time == transitionDuration)
        {
            Debug.Log("Loading");
            isCutscene = true;


        }
        if (Input.anyKeyDown && isCutscene)
        {
            Debug.Log("AAAAAA");
            Debug.Log("LoadingGame!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
