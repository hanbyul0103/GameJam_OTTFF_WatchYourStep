using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JUNG_MapManage : MonoBehaviour
{
    /* [SerializeField] private Transform[] bgobj;
     [SerializeField] private Transform[] groundobj;
     private Vector3[] groundTrm;
     private Vector3[] privateTrm;*/

    [SerializeField] private GameObject[] map;





    private Transform playerTrm;
    private Vector3 playerTrmSave;
    int moveToValue;
    int rand;
    private static JUNG_MapManage instance;

    public static JUNG_MapManage Instance
    {
        get
        {
            return instance;
        }
    }

    public int count = 0;
    private int setting;
    private void Awake()
    {
        if (Instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {
        playerTrmSave =(playerTrm = GameObject.FindWithTag("Player").GetComponent<Transform>()).position;


        count = 0;
        setting = 0;

        rand = Random.Range(0, map.Length);
        for(int i =0; i< map.Length; i++)
        {
            moveToValue += 60;
            GameObject randMap = Instantiate(map[rand], new Vector3(-moveToValue,0,0), Quaternion.identity);
        }


    

        
        

        /*
        privateTrm = new Vector3[bgobj.Length];
        groundTrm = new Vector3[groundobj.Length];



        for (int i = 0; i < bgobj.Length; i++)
        {
            privateTrm[i] = bgobj[i].position;
        }
        for (int i = 0; i < groundobj.Length; i++)
        {
            groundTrm[i] = groundobj[i].position;
        }*/
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Restart();
        }
    }


    public void SettingMap()
    {
        moveToValue += 480;
        
       /* ++count;
        if (count == 4)
        {
            count = 0;
            if (setting == 0)
            {
                bgobj[setting].position -= new Vector3(480, 0, 0);
                ++setting;
            }
            else if (setting == 1)
            {
                bgobj[setting].position -= new Vector3(480, 0, 0);
                --setting;
            }
        }*/
    }

   /* public void Restart()
    {

        bgobj[0].position = privateTrm[0];
        bgobj[1].position = privateTrm[1];

        playerTrm.position = playerTrmSave;

        for (int i = 0; i < groundobj.Length; i++)
        {
            groundobj[i].position = groundTrm[i];
        }

        setting = 0;
        count = 0;
    }*/
}
