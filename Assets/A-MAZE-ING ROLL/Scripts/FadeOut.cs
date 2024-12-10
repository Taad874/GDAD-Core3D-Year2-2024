using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    public bool fadeIn;
    public bool fadeOut;
   

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime;
                if (_canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                    fadeOut = false;
                    _canvasGroup.alpha = 1;
                }
            }
        }
        if(fadeOut)
        {
            if (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime;
                if (_canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                    //StartCoroutine(Wait());
                }
            }
        }
    }
    
}
