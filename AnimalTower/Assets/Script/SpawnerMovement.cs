using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    public bool gameOver = false;
    
    AudioSource SE;

    public float upStep = 0.5f;

    bool letGo = false;

    GameObject currentAnimal;
    public GameObject[] PrefabAnimal;

    public float moveStep = 0.5f;

    float angle = 0.0f;
    public float turnAngle = 10.0f;

    void Start()
    {
        
        SE = GetComponent<AudioSource>();

        int index = Random.Range(0, PrefabAnimal.Length);
        currentAnimal = Instantiate(PrefabAnimal[index]);
        currentAnimal.transform.position = transform.position;
        currentAnimal.transform.rotation = transform.rotation;
        currentAnimal.GetComponent<Rigidbody2D>().simulated = false;
    }

    void Update()
    {
        if (gameOver)
            return;


        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();  // 呼叫向左移動的 method
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnAnimal();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LetGoAnimal();
        }

        if (currentAnimal != null)
        {
            currentAnimal.transform.position = transform.position;
            currentAnimal.transform.rotation = transform.rotation;
        }
    }

    // 新增的向左移動 method
    public void MoveLeft()
    {

        if (gameOver)
            return;
        Vector3 pos = transform.position;
        pos.x = pos.x - moveStep;
        transform.position = pos;
    }
 
    public void MoveRight()
    {
        if (gameOver)
            return;
        Vector3 pos = transform.position;
        pos.x = pos.x + moveStep;
        transform.position = pos;
    }

    public void Rotate()
    {
        if (gameOver)
            return;
        angle = angle + turnAngle;
        Vector3 rot = new Vector3(0.0f, 0.0f, angle);
        transform.eulerAngles = rot;
    }

    public void SpawnAnimal()
    {
        if (gameOver)
            return;
        if (currentAnimal == null)
        {
            int index = Random.Range(0, PrefabAnimal.Length);
            currentAnimal = Instantiate(PrefabAnimal[index]);
            currentAnimal.transform.position = transform.position;
            currentAnimal.transform.rotation = transform.rotation;
            currentAnimal.GetComponent<Rigidbody2D>().simulated = false;
        }
    }

   public void LetGoAnimal()
   {
        if (gameOver)
            return;
        if (currentAnimal != null)
        {
            letGo = true;
            currentAnimal.GetComponent<Rigidbody2D>().simulated = true;
            currentAnimal = null;

            Vector3 pos = transform.position;
            pos.y = pos.y + upStep;
            transform.position = pos;

            SE.Play();

        }
    }
    

}