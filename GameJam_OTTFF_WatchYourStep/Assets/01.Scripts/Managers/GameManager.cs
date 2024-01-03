using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerMovement player;

    public bool isGameStart = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {

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
