using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    public List<GameObject> map = new List<GameObject>();
    public List<Transform> backMap = new List<Transform>();

    private GameObject[] activemaps;

    private int rand = 0;
    private int count = 0;
    private int setting = 0;
    private int bgmoveto = 480;
    private int groundmoveTo = 0;

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
            _currentMap.transform.position = new Vector3(groundmoveTo, 0, -7);
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
    }
    public void RandomMap()
    {
        ++count;
        if (count == 4)
        {
            count = 0;
            if (setting == 0)
            {
                backMap[setting].position -= new Vector3(bgmoveto, 0, 0);
                ++setting;
            }
            else if (setting == 1)
            {
                backMap[setting].position -= new Vector3(bgmoveto, 0, 0);
                --setting;
            }
        }
        rand = UnityEngine.Random.Range(0, map.Count);
        PoolManager.Instance.Pop(map[rand].name, new Vector3(groundmoveTo, 0, -7), Quaternion.identity);

        groundmoveTo -= 60;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) Starting();
        if (Input.GetMouseButtonDown(0)) Resetting();

    }

    public void Starting()
    {
        groundmoveTo = 0;
        for (int i = 0; i < map.Count; i++)
        {
            rand = UnityEngine.Random.Range(0, map.Count);
            PoolManager.Instance.Pop(map[rand].gameObject.name, new Vector3(groundmoveTo, 0, -7), Quaternion.identity);
            groundmoveTo -= 60;
        }
    }
    public void Resetting()
    {
        activemaps = GameObject.FindGameObjectsWithTag("Map");
        
        for(int i =0; i <activemaps.Length;i++)
        {
            if (activemaps[i].activeInHierarchy == true)
            PoolManager.Instance.Push(activemaps[i].name, activemaps[i]);
        }
    } 
}
