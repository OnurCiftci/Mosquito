using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour {

	public float speed;

	public GameObject cloud;
	public Transform cloudposition;


	// Use this for initialization
	void Start () {

		Instantiate (cloud, cloudposition.position, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
