using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    public float upStep = 0.5f;

    bool letGo = false;

    GameObject currentEnemy;
    public GameObject[] PrefabEnemy;

    public float moveStep = 0.5f;

    float angle = 0.0f;
    public float turnAngle = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, PrefabEnemy.Length);
        currentEnemy = Instantiate(PrefabEnemy[index]);
        currentEnemy.transform.position = transform.position;
        currentEnemy.transform.rotation = transform.rotation;
        currentEnemy.GetComponent<Rigidbody2D>().simulated = false;
    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + moveStep;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - moveStep;
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            angle = angle + turnAngle;
            Vector3 rot = new Vector3(0.0f, 0.0f, angle);
            transform.eulerAngles = rot;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (currentEnemy == null)
            {
                int index = Random.Range(0, PrefabEnemy.Length);
                currentEnemy = Instantiate(PrefabEnemy[index]);
                currentEnemy.transform.position = transform.position;
                currentEnemy.transform.rotation = transform.rotation;
                currentEnemy.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentEnemy != null)
            {
                letGo = true;
                currentEnemy.GetComponent<Rigidbody2D>().simulated = true;
                currentEnemy = null;

                //moveUP
                Vector3 pos = transform.position;
                pos.y = pos.y + upStep;
                transform.position = pos;
            }
        }

        if (currentEnemy != null)
        {
            currentEnemy.transform.position = transform.position;
            currentEnemy.transform.rotation = transform.rotation;
        }
    }
}
