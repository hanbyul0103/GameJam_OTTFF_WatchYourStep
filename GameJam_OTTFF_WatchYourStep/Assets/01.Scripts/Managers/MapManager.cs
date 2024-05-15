using System.Collections.Generic;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public List<GameObject> map = new List<GameObject>();
    public List<Transform> backMap = new List<Transform>();

    private GameObject[] activemaps;

    private int rand = 0;
    private int count = 0;
    private int setting = 0;
    private int bgmoveto = 720;
    private int groundmoveTo = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RandomMap()
    {
        ++count;
        if (count == 4)
        {
            count = 0;

            backMap[setting].position -= new Vector3(bgmoveto, 0, 0);

            setting = setting == 0 ? ++setting : --setting;
        }
        MapInstantiate();
    }

    public void Starting()
    {
        Resetting();
        groundmoveTo = -15;
        for (int i = 0; i < map.Count; i++)
        {
            MapInstantiate();
        }
    }

    public void Resetting()
    {
        activemaps = GameObject.FindGameObjectsWithTag("Map");

        for (int i = 0; i < activemaps.Length; i++)
        {
            if (activemaps[i].activeInHierarchy == true)
                PoolManager.Instance.Push(activemaps[i].name, activemaps[i]);
        }
    }

    private void MapInstantiate()
    {
        rand = Random.Range(0, map.Count);
        PoolManager.Instance.Pop(map[rand].gameObject.name, new Vector3(groundmoveTo, 0, 0), Quaternion.identity);
        groundmoveTo -= 90;
    }


    public void TitleViewMap()
    {
        Resetting();
        groundmoveTo = -15;
        for (int i = 0; i < map.Count; ++i)
        {
            PoolManager.Instance.Pop(map[i].gameObject.name, new Vector3(groundmoveTo, 0, 0), Quaternion.identity);
            groundmoveTo -= 90;
        }
    }
}
