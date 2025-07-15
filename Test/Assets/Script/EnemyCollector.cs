using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Update");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy inbounded");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("They have reached the base");
            Debug.Log("Game over");
            Debug.Log("Destroy");
            Destroy(collision.gameObject, 3);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
