using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Action onEnemySpawn;

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

    public Slider _musicSlider, _sfxSlider, _penaltySlider;

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

    [SerializeField] private Sprite[] miniHumanSprites;
    private Image miniHumanImage;

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

        miniHumanImage = GameObject.Find("MiniHuman").GetComponent<Image>();

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

    private void OnPanel(RectTransform panelName)
    {
        panelName.DOScale(1, dotTime).SetEase(Ease.InSine);
        GameManager.Instance.isPanelOpen = true;
    }

    private void OffPanel(RectTransform panelName)
    {
        panelName.DOScale(0, dotTime).SetEase(Ease.InSine);
        GameManager.Instance.isPanelOpen = false;
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

    public void ExitButton() // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
    {
        Application.Quit();
    }

    public void GameStartButton() {
        GameManager.Instance.GameStart();
        MapManager.Instance.Starting();
        OffTitlePanel();
        OnInGamePanel();
    }

    public void HomeButton() // Å¸ï¿½ï¿½Æ² È­ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ìµï¿½
    {
        CameraManager.Instance.TitleCamera();
        ScoreManager.Instance.ResetScore();
        GameManager.Instance.ResetGame();
        MapManager.Instance.TitleViewMap();
        OffGameOver();
        OnTitlePanel();
    }

    public void RestartButton() // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½
    {
<<<<<<< Updated upstream
        onEnemySpawn?.Invoke();

        CameraManager.Instance.FollowingCamera();
        GameManager.Instance.InvokeGameStart();
=======
        GameManager.Instance.ResetGame();
        GameManager.Instance.GameStart();
>>>>>>> Stashed changes
        ScoreManager.Instance.ResetScore();
        MapManager.Instance.Starting();
        OffGameOver();
        OnInGamePanel();
        SliderValueChangeing();
    }
    
    public void OnSettingPanel() // ï¿½ï¿½ï¿½ï¿½Ã¢ Å°ï¿½ï¿½
    {
        AudioManager.Instance.PlaySFX("ButtonSound");
        startButton.gameObject.SetActive(false);
        OnPanel(settingPanel);
    }

    public void OffSettingPanel() // ï¿½ï¿½ï¿½ï¿½Ã¢ ï¿½ï¿½ï¿½ï¿½
    {
        AudioManager.Instance.PlaySFX("ButtonSound");
        startButton.gameObject.SetActive(true);
        OffPanel(settingPanel);
    }

    public void OffGameOver() // ï¿½ï¿½ï¿½Ó¿ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
    {
        AudioManager.Instance.PlaySFX("ButtonSound");
        OffPanel(gameOverPanel);
    }

    public void OnInGamePanel()
    {
        OnPanel(ingamePanel);
    }

    public void OffInGamePanel()
    {
        OffPanel(ingamePanel);
    }

    public void OnExplainPanel()
    {
        AudioManager.Instance.PlaySFX("ButtonSound");
        startButton.gameObject.SetActive(false);
        OnPanel(explainPanel);
    }

    public void OffExplainPanel()
    {
        AudioManager.Instance.PlaySFX("ButtonSound");
        startButton.gameObject.SetActive(true);
        OffPanel(explainPanel);
    }

    public void OnTitlePanel()
    {
        foreach (var item in titlePanelItems)
        {
            item.DOFade(1, 1);
        }

        touchText.DOFade(1, 1);
        OnPanel(titlePanel);
    }

    public void OffTitlePanel()
    {
        foreach (var item in titlePanelItems)
        {
            item.DOFade(0, 1);
        }

        touchText.DOFade(0, 1);
        OffPanel(titlePanel);
    }

    public void TimeOverPanel()
    {
        miniHumanImage.sprite = miniHumanSprites[0];

        string[] narrations =
            { "ï¿½ï¿½ï¿½ï¿½?", "ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½Ì»ï¿½ï¿½Ï³ï¿½", "Å¸ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½", "ï¿½ï¿½Â¥ ï¿½ï¿½ï¿½Ñ´ï¿½ ï¿½ï¿½ï¿½ï¿½",
            "ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½~", "ï¿½Ì°ï¿½ ï¿½×³ï¿½", "ï¿½ï¿½ï¿½ï¿½!!", "ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½"};

        int rd = Random.Range(0, narrations.Length);

        narration.text = narrations[rd];

        OnPanel(gameOverPanel);
    }

    public void GameOverPanel()
    {
        miniHumanImage.sprite = miniHumanSprites[1];

        string[] narrations =
<<<<<<< Updated upstream
        { "»ì·ÁÁà", "¹«°Å¿ö", "³ª ¸ÕÀú °¥°Ô..", "¤Ð¤Ñ¤Ð", "³×°¡ ¹ºµ¥\n³¯ Á×¿©",
            "²Ð", "³»°¡ Á×¾ú´Ù´Ï...", "ÀÌ ³ª»Û °ÅÀÎ...", "Èþ...¤Ð¤Ñ¤Ð", "ÀÌ ¸øµÈ °ÅÀÎ¾Æ",
            "¾Æ¾ß..", "³Ê¹«ÇØ", "¿Ö ¹â¾Æ", "Áö³ª°¥°Å¸é\nÀß Á» Áö³ª°¡Áö...", "³Ê¹« ¾ÆÇÁÀÝ¾Æ"
=======
        { "ï¿½ï¿½ï¿½ï¿½ï¿½", "ï¿½ï¿½ï¿½Å¿ï¿½", "ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½\nï¿½ï¿½ï¿½ï¿½..", "ï¿½Ð¤Ñ¤ï¿½", "ï¿½×°ï¿½ ï¿½ï¿½ï¿½ï¿½\nï¿½ï¿½ ï¿½×¿ï¿½",
            "ï¿½ï¿½", "ï¿½ï¿½ï¿½ï¿½\nï¿½×¾ï¿½ï¿½Ù´ï¿½...", "ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½...", "ï¿½ï¿½...ï¿½Ð¤Ñ¤ï¿½", "ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Î¾ï¿½",
            "ï¿½Ð¤Ñ¤ï¿½", "ï¿½Æ¾ï¿½..", "ï¿½Ê¹ï¿½ï¿½ï¿½", "ï¿½ï¿½ ï¿½ï¿½ï¿½", "ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Å¸ï¿½\nï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½...", "ï¿½Ê¹ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ý¾ï¿½"
>>>>>>> Stashed changes
        };

        int rd = Random.Range(0, narrations.Length);

        narration.text = narrations[rd];

        OnPanel(gameOverPanel);
    }

    public void SliderValueChangeing()
    {
        StopCoroutine("Penalting");
        _penaltySlider.value = _penaltySlider.maxValue;
        StartCoroutine("Penalting");
    }

    public IEnumerator Penalting()
    {
        while (_penaltySlider.value != 0)
        {
            _penaltySlider.value -= Time.deltaTime;
            yield return null;
        }

        GameManager.Instance.GameOver();
        TimeOverPanel();
    }
}
