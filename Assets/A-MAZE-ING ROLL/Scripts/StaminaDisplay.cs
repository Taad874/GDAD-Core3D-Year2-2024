using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaminaDisplay : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    public bool fadeIn;
    public bool fadeOut;


 
    private PlayerMovement player;
    private Image fillImage;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        fillImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount = player.GetStamina() / player.GetMaxStamina();
        if (fillImage.fillAmount == 1f)
        {
            
            fadeOut = true;
        }
        else
        {
            
            fadeIn = true;
        }



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
        if (fadeOut)
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
