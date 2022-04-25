using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public GameObject player;

    public void SetMaxXP(int NextLevelXP)
    {
        slider.maxValue = NextLevelXP;
    }

    public void SetCurrentXP(int CurrentXP)
    {
        slider.value = CurrentXP;
    }
}
