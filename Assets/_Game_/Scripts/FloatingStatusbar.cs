using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingStatusbar : MonoBehaviour
{

    [SerializeField] private Slider slider;


    public void UpdateStatusBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void Update()
    {

    }
}
