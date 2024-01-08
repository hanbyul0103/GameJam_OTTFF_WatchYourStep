using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action onEnemySpawn;

    private PlayerMovement player;

    public bool isGameStart = false;
    public bool isPanelOpen = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        player = FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        MapManager.Instance.Starting();
        AudioManager.Instance.PlayMusic("BGMCitySound");
        AudioManager.Instance.PlayMusic("BGMSound");
    }

    public void GameStart()
    {
        isGameStart = true;
    }

    public void GameOver(bool isTimeOver = false)
    {
        player.animator.SetBool("isGameStart", false);
        isGameStart = false;
        UIManager.Instance.OnGameOver(isTimeOver);
        UIManager.Instance.OffInGamePanel();
        UIManager.Instance.StopSliderValueChange();
        ScoreManager.Instance.SetGameOver();
    }

    public void GameStartRoutine()
    {
        UIManager.Instance.SliderValueChangeing();
        if (isPanelOpen) return;
        AudioManager.Instance.PlaySFX("ButtonSound");
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        // º“»Ø
        onEnemySpawn?.Invoke();
        UIManager.Instance.OffTitlePanel();
        UIManager.Instance.OnInGamePanel();
        CameraManager.Instance.FollowingCamera();
        yield return new WaitForSeconds(0.3f);
        isGameStart = true;
    }
}
