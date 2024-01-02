using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image settingPanel;
    [SerializeField] Image gameOverPanel;
    [SerializeField] Sprite checkBox;
    [SerializeField] Button bgmButton;
    [SerializeField] Button sfxButton;

    public Slider _musicSlider, _sfxSlider;
    Sprite originImg;

    public float dotTime = 0.5f;

    private bool onBGM = true;
    private bool onSFX = true;

    private void Start()
    {
        originImg = bgmButton.image.sprite;
    }

    public void ToggleMusic()
    {
        if (onBGM)
        {
            bgmButton.image.sprite = checkBox;
            onBGM = false;
        }
        else if(!onBGM)
        {
            bgmButton.image.sprite = originImg;
            onBGM=true;
        }
            
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        if (onSFX)
        {
            sfxButton.image.sprite = checkBox;
            onSFX = false;
        }
        else if(!onSFX)
        {
            sfxButton.image.sprite = originImg;
            onSFX=true;
        }

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

    public void SettingButton() // 설정창 키기
    {
        settingPanel.rectTransform.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void XButton() // 설정창 끄기
    {
        settingPanel.rectTransform.DOScale(0, dotTime).SetEase(Ease.InSine);
    }

    public void ExitButton() // 게임 끄기
    {
        Application.Quit();
    }

    public void HomeButton() // 타이틀 화면으로 이동
    {
        // SceneManager.LoadScene("MainScene");
    }

    public void RestartButton() // 게임 재시작
    {
        // SceneManager.LoadScene("GameScene");
    }

    public void OnGameOver() // 게임오버 오픈
    {
        gameOverPanel.rectTransform.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void OffGameOver() // 게임오버 끄기
    {
        gameOverPanel.rectTransform.DOScale(0, dotTime).SetEase(Ease.InSine);
    }
}
