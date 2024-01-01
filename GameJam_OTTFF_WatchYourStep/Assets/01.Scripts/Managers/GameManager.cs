using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        AudioManager.Instance.PlayMusic("Theme");
    }

    public void GameOver()
    {
        AudioManager.Instance.musicSource.Stop();
    }
}
