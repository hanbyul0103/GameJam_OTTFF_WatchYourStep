using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private int distance;
    private int combo;
    private int multiply = 1;

    private void Update()
    {
        if (combo >= 10)
        {
            multiply = 2;
        }

        else
        {
            multiply = 1;
        }
    }

    private void CountCombo()
    {

    }

    public void AddDistance()
    {
        distance = distance * multiply;
    }
}
