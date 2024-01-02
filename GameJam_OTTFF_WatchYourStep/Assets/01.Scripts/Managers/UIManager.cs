using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image settingPanel;

    public Slider _musicSlider, _sfxSlider;

    public float dotTime = 0.5f;
    
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

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

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
