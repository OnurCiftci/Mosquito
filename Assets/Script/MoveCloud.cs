using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour {
    public ScoreManager manager;
	public float speed;
	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (speed < 7)
        {
            speed = manager.generalcounter + speed;
        }
        transform.Translate (Time.deltaTime*-speed, 0, 0);
		if (transform.position.x < -30) {
			transform.position = new Vector3(15,transform.position.y,transform.position.z);
			}

	}
}
