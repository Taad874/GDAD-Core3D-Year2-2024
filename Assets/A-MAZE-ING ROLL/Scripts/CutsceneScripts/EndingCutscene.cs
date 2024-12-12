using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector transition;
    private double transitionDuration;

    private bool isCutscene;


    private void Awake()
    {
        transition = transition.GetComponent<PlayableDirector>();
        transitionDuration = transition.GetComponent<PlayableDirector>().duration;
        Debug.Log(transitionDuration);
    }
   

    // Update is called once per frame
    void Update()
    {
       
        if (transitionDuration <= transition.time)
        {
            Debug.Log("Loading");
            isCutscene = true;


        }
        if (Input.anyKeyDown && isCutscene)
        {
            
            Debug.Log("LoadingGame!");
            SceneManager.LoadScene("Opening");
        }
        
    }
}
