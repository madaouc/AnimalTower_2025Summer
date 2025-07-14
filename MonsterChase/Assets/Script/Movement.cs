using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool onGround = true;

    public float moveStep = 0.5f;
    Rigidbody2D myBody;
    public Vector3 JumpForce = new Vector3 (0f, 3.0f,0f);
    

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + moveStep;
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - moveStep;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (onGround == true) )
        {
            Debug.Log("Jump");
            myBody.AddForce(JumpForce, ForceMode2D.Impulse);
            onGround = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

}
