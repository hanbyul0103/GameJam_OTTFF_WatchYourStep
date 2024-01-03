using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public List<GameObject> map = new List<GameObject>();
    public List<Transform> backMap = new List<Transform>();

    private GameObject _currentMap;

    private int rand = 0;
    private int count = 0;
    private int setting = 0;
    private int bgmoveto = 480;
    private int groundmoveTo = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("pop");
        for (int i = 0; i < map.Count; i++)
        {
            rand = UnityEngine.Random.Range(0, map.Count);
            PoolManager.Instance.Pop(map[rand].gameObject.name, new Vector3(groundmoveTo, 0, -7), Quaternion.identity);
            groundmoveTo -= 60;
        }
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
}
