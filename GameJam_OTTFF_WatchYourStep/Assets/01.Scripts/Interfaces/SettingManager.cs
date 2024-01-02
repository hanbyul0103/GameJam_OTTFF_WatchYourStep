using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SettingManager : MonoBehaviour
{
    [SerializeField] Image settingPanel;


    public float dotTime = 0.5f;

    public void SettingButton()
    {
        settingPanel.rectTransform.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void SettingXButton()
    {
        settingPanel.rectTransform.DOScale(0, dotTime).SetEase(Ease.InSine);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    
    public void HomeButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
