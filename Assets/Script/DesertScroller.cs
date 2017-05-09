using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertScroller : MonoBehaviour {
    public GameObject desert;
    public Transform desertposition;

    

	// Use this for initialization
	void Start () {
        
        Instantiate(desert, desertposition.position, Quaternion.identity);
       
	}
	
	// Update is called once per frame
	void Update () {

	}
}
