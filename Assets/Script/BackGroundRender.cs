using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRender : MonoBehaviour {

	public GameObject background;
	public Transform backgroundposition;


	// Use this for initialization
	void Start () {

		Instantiate (background, backgroundposition.position, Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {



	}
}
