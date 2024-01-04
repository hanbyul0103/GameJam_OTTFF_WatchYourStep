using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }

    public void GameStart()
    {
        isGameStart = true;
    }

    public void GameOver()
    {
        player.animator.SetBool("isGameStart", false);
        isGameStart = false;
        UIManager.Instance.OnGameOver();
        UIManager.Instance.OffInGamePanel();
        ScoreManager.Instance.SetGameOver();
    }

    public void GameStartRoutine()
    {
        if (isPanelOpen) return;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        UIManager.Instance.OffTitlePanel();
        UIManager.Instance.OnInGamePanel();
        CameraManager.Instance.FollowingCamera();
        yield return new WaitForSeconds(0.3f);
        isGameStart = true;
    }
}
