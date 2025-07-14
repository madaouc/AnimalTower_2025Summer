using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerMovementTest : MonoBehaviour
{
    public float upStep = 0.5f;
    
    bool letGo = false;
    
    GameObject currentAnimal;
    public GameObject[] PrefabAnimal;

    GameObject[] pastAnimals;
    float yOffset = 7.0f;

    public float moveStep = 0.5f;
    
    float angle = 0.0f;
    public float turnAngle = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, PrefabAnimal.Length);
        currentAnimal = Instantiate(PrefabAnimal[index]);
        currentAnimal.transform.position = transform.position;
        currentAnimal.transform.rotation = transform.rotation;
        currentAnimal.GetComponent<Rigidbody2D>().simulated = false;


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

        if(Input.GetKeyDown(KeyCode.E))
        {
            angle = angle + turnAngle;
            Vector3 rot = new Vector3(0.0f, 0.0f, angle);
            transform.eulerAngles = rot;
        }

        

        //Generate Animal / Spawn Animal
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (currentAnimal == null)
            {

                pastAnimals = GameObject.FindGameObjectsWithTag("Animal");
                Debug.Log("Try Get Animals");
                if (pastAnimals != null)
                {
                    Debug.Log("Got Animals");
                    float topY = -100.0f;
                    foreach (GameObject ani in pastAnimals)
                    {
                        if (ani != null)
                            if (ani.transform.position.y > topY)
                                topY = ani.transform.position.y;
                    }
                    if (topY + yOffset > transform.position.y)
                    {
                        Debug.Log("topY: " + topY);
                        Vector3 pos = transform.position;
                        pos.y = topY+ yOffset;
                        transform.position = pos;
                        
                    }
                }


                int index = Random.Range(0, PrefabAnimal.Length);
                currentAnimal = Instantiate(PrefabAnimal[index]);
                currentAnimal.transform.position = transform.position;
                currentAnimal.transform.rotation = transform.rotation;
                currentAnimal.GetComponent<Rigidbody2D>().simulated = false;

                
            }
        }

        //LetGo
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (currentAnimal != null)
            {
                letGo = true;
                currentAnimal.GetComponent<Rigidbody2D>().simulated = true;
                currentAnimal = null;

                //moveUP
                //Vector3 pos = transform.position;
                //pos.y = pos.y + upStep;
                //transform.position = pos;
            }
        }


       
      
        //Animal Follows
        if(currentAnimal != null)
        {
            currentAnimal.transform.position = transform.position;
            currentAnimal.transform.rotation = transform.rotation;
        }
    }
}
