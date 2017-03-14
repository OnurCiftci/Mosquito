using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float wingforce = 10.0f;
    public float flyforce = 5.0f;
    Rigidbody2D RGB;
    bool isGrounded = false;
	// Use this for initialization
	void Start () {
        RGB = transform.GetComponent < Rigidbody2D >();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded != true)
         RGB.AddForce(Vector3.up * (wingforce * RGB.mass * RGB.gravityScale * 20.0f));
        if (Input.GetKey(KeyCode.Space) && isGrounded != true)
            RGB.AddForce(Vector3.up * (flyforce * RGB.mass * RGB.gravityScale * 2.0f));


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
        
        else if (collision.collider.tag == "BonusTaker")
        {
            Destroy(collision.gameObject);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
    }
}
