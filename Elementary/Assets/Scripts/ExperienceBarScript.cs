using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBarScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textUI;

    public void SetMaxXP(int xp)
    {
        slider.maxValue = xp;
        slider.value = 0;

        textUI.text = 0 + "/" + xp;
    }

    public void SetXP(int xp)
    {
        textUI.text = xp + "/" + slider.maxValue;

        slider.value = xp;
    }

}
