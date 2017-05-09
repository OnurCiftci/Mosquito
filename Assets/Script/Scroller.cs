using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {

    public float scrollSpeed = 2.0f;
	public GameObject bird;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    public float counter = 0.0f;
	public Transform challangesSpawnPoint;
	public laserScript lsr;
	public int leftlaser;
	public Text laserleft;

    private int qucikcounter;
	


	// Use this for initialization
	void Start () {
        qucikcounter = 0;
        //GenerateRandomChallenge();
        leftlaser = PlayerPrefs.GetInt ("LASERCOUNT");
		lsr = FindObjectOfType<laserScript> ();


}
	
	// Update is called once per frame
	void Update () {
		if (leftlaser >= 0) {
			laserleft.text = "Bonus :" + leftlaser;
		}


        GameObject currentChild;

        if (counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
            counter -= Time.deltaTime * frequency;
            


        for(int i =0; i< transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollEnemy(currentChild);




            if (currentChild.transform.position.x < -20.0f )
            {
                Destroy(currentChild);
            }

				
			if (Input.GetKeyDown (KeyCode.F) && leftlaser > 0){
				

			if (bird.transform.position.y >= currentChild.transform.position.y - 3 && bird.transform.position.y <= currentChild.transform.position.y + 3  ) {
					Destroy (currentChild);
				}

			}

        }

		if (Input.GetKeyDown (KeyCode.F) && leftlaser >-1) {
			leftlaser--;
			if (leftlaser >= 0) {
				PlayerPrefs.SetInt ("LASERCOUNT", leftlaser);
			}


		}


		
	}
    void ScrollEnemy(GameObject currentEnemy)
    {
		Vector2 pos;
		pos = currentEnemy.transform.position;
		pos.x -= scrollSpeed * Time.deltaTime;
		currentEnemy.transform.position = pos;
    }

    void GenerateRandomChallenge()
    {
        int i = Random.Range(0, challenges.Length);


        if (challenges[i].gameObject.tag!="sarma")
        {
            
            challangesSpawnPoint.position = new Vector3(Random.Range(11f, 20f), -3.3f, challangesSpawnPoint.position.z);
        }
        else
        {
            challangesSpawnPoint.position = new Vector3(Random.Range(11f, 20f), 3.5f, challangesSpawnPoint.position.z);
        }
        //Debug.Log(challenges[i].gameObject.tag);

        GameObject newChallenge = Instantiate(challenges[i],challangesSpawnPoint.position,Quaternion.identity) as GameObject;

        if (PlayerPrefs.GetInt("QUICKSTART") == 1 && qucikcounter<20)
        {
            qucikcounter += 1;
            challenges[i].gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
        else
        {
            challenges[i].gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;

        }
        newChallenge.transform.parent = transform;
        if (scrollSpeed < 12)
            counter = 1.0f;
        else
            counter = 0.4f;
    }


}
