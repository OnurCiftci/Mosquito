using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	public float speed;
	Vector2 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;
		
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "end") {
			Destroy (transform.gameObject);

		}
	}
}
