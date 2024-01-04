using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyManage : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider.maxValue = 10;
        slider.value = 5;
    }

    private void FixedUpdate()
    {
        slider.value -= Time.deltaTime;
        if(slider.value <= 0)
        {
            //UIManager.Instance.OnGameOver();
        }
    }

    public void GetCheack()
    {
        slider.value = slider.maxValue;
    }
}
    