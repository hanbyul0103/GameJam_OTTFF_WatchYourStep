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
