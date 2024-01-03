using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private Sprite checkBox;
    [SerializeField]
    private Button bgmButton;
    [SerializeField]
    private Button sfxButton;
    [SerializeField]
    private List<Image> titlePanelItems = new List<Image>();
    [SerializeField] 
    private TextMeshProUGUI narration;

    public Slider _musicSlider, _sfxSlider;

    public float dotTime = 0.5f;

    private RectTransform titlePanel;
    private RectTransform settingPanel;
    private RectTransform gameOverPanel;
    private RectTransform ingamePanel;
    private RectTransform explainPanel;
    private RectTransform startButton;
    private TextMeshProUGUI touchText;
    private Sprite originImg;
    private PlayerMovement player;

    private bool onBGM = true;
    private bool onSFX = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        titlePanel = GameObject.Find("TitlePanel").GetComponent<RectTransform>();
        settingPanel = GameObject.Find("SettingPanel").GetComponent<RectTransform>();
        gameOverPanel = GameObject.Find("GameOverPanel").GetComponent<RectTransform>();
        ingamePanel = GameObject.Find("GamePlayPanel").GetComponent<RectTransform>();
        explainPanel = GameObject.Find("ExpainPanel").GetComponent<RectTransform>();
        startButton = GameObject.Find("Panel").GetComponent<RectTransform>();
        touchText = GameObject.Find("TouchText").GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerMovement>();

        titlePanelItems = titlePanel.GetComponentsInChildren<Image>().ToList();
        titlePanelItems.RemoveAt(0);
    }

    private void Start()
    {
        originImg = bgmButton.image.sprite;

        settingPanel.DOScale(0, 0);
        gameOverPanel.DOScale(0, 0);
        ingamePanel.DOScale(0, 0);
        explainPanel.DOScale(0, 0);
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
        player.transform.position = player.playerOriginTransform.position;
        OffGameOver();
        OnTitlePanel();
        MapManager.Instance.Resetting();
        MapManager.Instance.Starting();
    }

    public void RestartButton() // 게임 재시작
    {
        CameraManager.Instance.FollowingCamera();
        GameManager.Instance.GameStart();
        player.transform.position = player.playerOriginTransform.position;
        OffGameOver();
        OnInGamePanel();
        MapManager.Instance.Resetting();
        MapManager.Instance.Starting();
    }

    public void OnGameOver() // 게임오버 오픈
    {
        gameOverPanel.DOScale(1, dotTime).SetEase(Ease.InSine);
        RandomNarrationText();
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

    public void OnExplainPanel()
    {
        explainPanel.DOScale(1, dotTime).SetEase(Ease.InSine);
    }

    public void OffExplainPanel()
    {
        explainPanel.DOScale(0, dotTime).SetEase(Ease.InSine);
    }

    public void OnTitlePanel()
    {
        foreach (var item in titlePanelItems)
        {
            item.DOFade(1, 1);
        }

        touchText.DOFade(1, 1);
        startButton.gameObject.SetActive(true);
    }

    public void OffTitlePanel()
    {
        foreach (var item in titlePanelItems)
        {
            item.DOFade(0, 1);
        }

        touchText.DOFade(0, 1);
        startButton.gameObject.SetActive(false);
    }

    private void RandomNarrationText()
    {
        string[] narrations =
            { "살려줘", "무거워", "나 먼저 갈게",
            "밍밍밍", "ㅠㅡㅠ", "너가 뭔데 날 죽여",
            "꽥", "내가 죽었다니...", "이 나쁜 거인...", "힝...ㅠㅡㅠ" };
        int rd = Random.Range(0, narrations.Length);

        narration.text = narrations[rd];
    }
}
