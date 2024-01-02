using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> map = new List<GameObject>();

    private int rand = 0;
    private int count = 0;
    private int moveTo = 0;

    private static MapManager instance;
    public static MapManager Instance
    {
        get
        {
            return instance;
        }
    }

    private GameObject _currentMap;

    public GameObject CurrentMap
    {
        get => _currentMap;
        set
        {
            _currentMap = value;
            _currentMap.transform.position = new Vector3(moveTo, 0, -7);
        }
    }

    private void Awake()
    {
        if (Instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        for (int i = 0; i < map.Count; i++)
        {
            rand = Random.Range(0, map.Count);
            PoolManager.Instance.Pop(map[rand].ToString(), new Vector3(moveTo, 0, -7), Quaternion.identity);
            moveTo-= 60;    
        }
    }
    public GameObject RandomMap()
    {
        PoolManager.Instance.Pop(map[Random.Range(0, map.Count)].ToString(), new Vector3(moveTo, 0, -7), Quaternion.identity);
        /*Instantiate(map[Random.Range(0, map.Count)], new Vector3(moveTo, 0, -7), Quaternion.identity);*/
        moveTo -= 60;
        return CurrentMap;
    }
}
