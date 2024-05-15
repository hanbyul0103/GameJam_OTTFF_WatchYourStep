using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action onEnemySpawn;

    private PlayerMovement player;     
    // private EnemySpawner enemySpawner;
   
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
        AudioManager.Instance.PlayMusic("BGMSound");
    }

<<<<<<< Updated upstream
    public void InvokeGameStart()
    {
        Invoke("GameStart", 0.5f);
    }

    private void GameStart()
=======
    public void GameStart() 
>>>>>>> Stashed changes
    {
        if(isPanelOpen || isGameStart) return;
        isGameStart = true;
        CameraManager.Instance.IngameCamera();
        player.animator.SetBool("isGameStart", true);
        /*enemySpawner.Spawn();*/ // 수정
    }

    public void GameOver()
    {
        isGameStart = false;
	    player.animator.SetBool("isGameStart", false);
    }

    public void ResetGame() {
        CameraManager.Instance.TitleCamera();
        player.transform.position = player.playerOriginTransform.position;
        /*enemySpawner.Despawn();*/ // 수정
    }
}
