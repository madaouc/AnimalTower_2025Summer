using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollector : MonoBehaviour
{
    public GameObject GameOverTxt;
    public GameObject spawner;
    
    AudioSource SE;
    
    // Start is called before the first frame update
    void Start()
    {
        SE= GetComponent<AudioSource>();
        //Debug.Log("hello");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Animal"))
        {
            Debug.Log("There's an Animal");
            Debug.Log("GameOver");
            Debug.Log("Destroy");
            Destroy(collision.gameObject,3);

            SE.Play();
            GameOverTxt.SetActive(true);
            //Time.timeScale = 0.0f;

            spawner.GetComponent<SpawnerMovement>().gameOver = true;
        }

    }

}
