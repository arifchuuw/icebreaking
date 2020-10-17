using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    bool jump;

    private float x;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if you press left it's x = -1, and right x = 1 of the axis
        x = Input.GetAxis("Horizontal");
        transform.position += (Vector3)new Vector2(x * speed * Time.deltaTime, 0);
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    //Physics calculations updated
    /*private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }*/


    void FixedUpdate()
    {
        if (jump)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }
}