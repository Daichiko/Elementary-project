using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI textUI;

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;

        fill.color = gradient.Evaluate(1f);

        textUI.text = Health + "/" + Health;
    }

    public void SetHealth(int Health)
    {
        textUI.text = Health + "/" + slider.maxValue;

        slider.value = Health;

        fill.color = gradient.Evaluate(slider.normalizedValue);  
    }

}
