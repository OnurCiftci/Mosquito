using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMountain : MonoBehaviour {

	public GameObject greenMountain,desert;
	public Transform greenMountainposition;
  


	// Use this for initialization
	void Start () {

		Instantiate (greenMountain, greenMountainposition.position, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {



	}
}