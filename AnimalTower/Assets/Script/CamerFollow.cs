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
        //���N�X
        //���o�ۤv(camera)���y�� -> x,y,z 
        //�N�JVector3 pos
        //���ۤv��y�y��
        //�ܬ�spawner y�y�СA�A��h�@�Ӽ�
        //�N�J�ۤv����m

        Vector3 pos = transform.position; // ���o�۾��ثe���y��

        // �]�w�۾���Y�y�Ь� spawner ��Y�y�ЦA��h�@�Ӽ�
        pos.y = spawner.transform.position.y - yOffset;

        // ��s�۾�����m
        transform.position = pos;

    }
}
