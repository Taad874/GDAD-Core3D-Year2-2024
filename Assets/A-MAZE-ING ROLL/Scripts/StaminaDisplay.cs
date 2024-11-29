using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StaminaDisplay : MonoBehaviour
{
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
        if (fillImage.fillAmount == player.GetMaxStamina())
        {
            fillImage.color = new Color(0,1,0,0);
            fillImage.GetComponentInParent<Graphic>().color = Color.clear; //find way to make parent disappear
        }
        else
        {
            fillImage.color = new Color(0, 1, 0, 1);
            
        }
    }
}
