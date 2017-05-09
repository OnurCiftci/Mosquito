using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGorund : MonoBehaviour {
	public float speed;
    public  int count = 0;
    // Use this for initialization
    public ScoreManager manager;
    void Start () {
        manager = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (speed < 10)
        {
            speed = manager.generalcounter + speed;
        }

        transform.Translate (Time.deltaTime * -speed, 0, 0);
		if (transform.position.x < -60) {
			transform.position = new Vector3(60,transform.position.y,transform.position.z);
            count += 1;
		
		}
        if (count >= 1 && count < 2)
        {
            transform.position = new Vector3(transform.position.x, -20, transform.position.z);


        }
        else if (count == 2)
        {
            count = 0;
            transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
        }
           
	}

    


}
