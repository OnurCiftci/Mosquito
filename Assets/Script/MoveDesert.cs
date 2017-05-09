using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDesert : MonoBehaviour {
    public float speed;
    public MoveBackGorund backgroundcount;
    public ScoreManager manager;
    // Use this for initialization
    void Start () {
        backgroundcount = FindObjectOfType<MoveBackGorund>();
        manager = FindObjectOfType<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (speed < 10)
        {
            speed = manager.generalcounter + speed;
        }

        transform.Translate(Time.deltaTime * -speed, 0, 0);
        if (transform.position.x < -60)
            transform.position = new Vector3(60, transform.position.y, transform.position.z);



        backgroundcount = FindObjectOfType<MoveBackGorund>();
      
        if (backgroundcount.count >= 1 && backgroundcount.count < 2)
        {
            transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        }

        else if(backgroundcount.count == 2 || backgroundcount.count == 0)
            transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);








    }





}
