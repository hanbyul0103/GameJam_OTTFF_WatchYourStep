using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite checkBox;
    [SerializeField]
    private Button bgmButton;
    [SerializeField]
    private Button sfxButton;

    public Slider _musicSlider, _sfxSlider;

    public float dotTime = 0.5f;

    private RectTransform settingPanel;
    private RectTransform gameOverPanel;
    private RectTransform ingamePanel;
    private Sprite originImg;

    private bool onBGM = true;
    private bool onSFX = true;

    private void Awake()
    {
        settingPanel = GameObject.Find("SettingPanel").GetComponent<RectTransform>();
        gameOverPanel = GameObject.Find("GameOverPanel").GetComponent<RectTransform>();
        ingamePanel = GameObject.Find("GamePlayPanel").GetComponent<RectTransform>();
    }

    private void Start()
    {
        originImg = bgmButton.image.sprite;

        settingPanel.DOScale(0, 0);
        gameOverPanel.DOScale(0, 0);
        ingamePanel.gameObject.SetActive(false);
    }

    public void ToggleMusic()
    {
        if (onBGM)
        {
            bgmButton.image.sprite = checkBox;
            onBGM = false;
        }
        else if (!onBGM)
        {
            bgmButton.image.sprite = originImg;
            onBGM = true;
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
        else if (!onSFX)
        {
            sfxButton.image.sprite = originImg;
            onSFX = true;
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
        settingPanel.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void XButton() // 설정창 끄기
    {
        settingPanel.DOScale(0, dotTime).SetEase(Ease.InSine);
    }

    public void ExitButton() // 게임 끄기
    {
        Application.Quit();
    }

    public void HomeButton() // 타이틀 화면으로 이동
    {
        CameraManager.Instance.TitleCamera();
    }

    public void RestartButton() // 게임 재시작
    {
        CameraManager.Instance.IngameCamera();
    }

    public void OnGameOver() // 게임오버 오픈
    {
        gameOverPanel.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void OffGameOver() // 게임오버 끄기
    {
        gameOverPanel.DOScale(0, dotTime).SetEase(Ease.InSine);
    }

    public void OnInGamePanel()
    {
        ingamePanel.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void OffInGamePanel()
    {
        ingamePanel.DOScale(0, dotTime).SetEase(Ease.InSine);
    }
}
