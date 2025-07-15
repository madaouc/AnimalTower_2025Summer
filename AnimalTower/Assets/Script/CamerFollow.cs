using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{

    public float yOffset = 2.0f;

    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //偽代碼
        //取得自己(camera)的座標 -> x,y,z 
        //代入Vector3 pos
        //更改自己的y座標
        //變為spawner y座標，再減去一個數
        //代入自己的位置

        Vector3 pos = transform.position; // 取得相機目前的座標

        // 設定相機的Y座標為 spawner 的Y座標再減去一個數
        pos.y = spawner.transform.position.y - yOffset;

        // 更新相機的位置
        transform.position = pos;

    }
}
