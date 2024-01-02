using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayMusic("BGM1");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            AudioManager.Instance.PlaySFX("GameOver");
        }
    }
}
