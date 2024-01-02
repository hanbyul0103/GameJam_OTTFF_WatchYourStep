using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JUNG_MapManage : MonoBehaviour
{
    [SerializeField] private Transform[] bgobj;
    [SerializeField] private Transform[] groundobj;
    [SerializeField] private Transform[] privateTrm;
    private static JUNG_MapManage instance;

    public static JUNG_MapManage Instance
    {
        get
        {
            return instance;
        }
    }

    public int count =0;
    private int setting;
    private void Awake()
    {
        if(Instance==null)
        instance = this;
        else
        Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        count = 0;
        setting = 0;
     
    }
  

    public void SettingMap()
    {
        ++count;
        if (count==4)
        {
            count = 0;
            if (setting == 0)
            {
                bgobj[setting].transform.position -= new Vector3(480, 0, 0);
                ++setting;
            }
            else if (setting == 1)
            {
                bgobj[setting].transform.position -= new Vector3(480, 0, 0);
                --setting;
            }
        }
    }
}
