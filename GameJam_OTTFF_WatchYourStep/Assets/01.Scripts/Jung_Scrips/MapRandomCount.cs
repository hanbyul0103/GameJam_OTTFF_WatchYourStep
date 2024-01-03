using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRandomCount : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Map"))
        {
            PoolManager.Instance.Push(other.gameObject.name, other.gameObject);
            MapManager.Instance.RandomMap();
        }
    }
}
