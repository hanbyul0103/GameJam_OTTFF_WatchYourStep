using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRnadCount : MonoBehaviour
{
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject mapObj = MapManager.Instance.RandomMap();
            PoolManager.Instance.Push(gameObject.ToString(), gameObject);
        }
    }
}
