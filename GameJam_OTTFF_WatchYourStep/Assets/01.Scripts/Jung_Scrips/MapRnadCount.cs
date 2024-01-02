using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRnadCount : MonoBehaviour
{
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            JUNG_MapManage.Instance.SettingMap();
            transform.position -= new Vector3( 480 , 0, 0) ;
        }
    }
}
