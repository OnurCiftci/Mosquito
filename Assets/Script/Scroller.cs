using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    public float scrollSpeed = 2.0f;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challangesSpawnPoint;
	// Use this for initialization
	void Start () {
        GenerateRandomChallenge();
	}
	
	// Update is called once per frame
	void Update () {
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
            if (currentChild.transform.position.x < -40.0f)
            {
                Destroy(currentChild);
            }
        }

		
	}
    void ScrollEnemy(GameObject currentEnemy)
    {
        currentEnemy.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime) ;
    }

    void GenerateRandomChallenge()
    {
        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)],challangesSpawnPoint.position,Quaternion.identity) as GameObject;

        newChallenge.transform.parent = transform;
        counter = 2.0f;

    }
}
