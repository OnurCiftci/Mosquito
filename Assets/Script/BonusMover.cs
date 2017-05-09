using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMover : MonoBehaviour
{

    public float scrollSpeed = 2.0f;
    int floataround = 0;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challangesSpawnPoint;
    // Use this for initialization
    void Start()
    {
        GenerateRandomChallenge();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject currentChild;


        if (counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
            counter -= Time.deltaTime * frequency;



        for (int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            ScrollEnemy(currentChild);
            if (currentChild.transform.position.x < -20.0f)
            {
                Destroy(currentChild);
            }
        }


    }
    void ScrollEnemy(GameObject currentEnemy)
    {
		Vector2 pos;
		pos = currentEnemy.transform.position;pos.x -= scrollSpeed * Time.deltaTime;
		currentEnemy.transform.position = pos;
		if (floataround < 100)
        {
			pos.y += (scrollSpeed * Time.deltaTime);
			currentEnemy.transform.position = pos;
            
        }
        
        
        if (floataround <= 350 && floataround > 100)
        {
            
            currentEnemy.transform.position -= Vector3.up * (scrollSpeed * Time.deltaTime)/2;
            
        }

        if (floataround >350)
        {
            floataround = 0;

        }
        floataround++;


    }
    void GenerateRandomChallenge()
    {
		challangesSpawnPoint.position = new Vector3 (challangesSpawnPoint.position.x, challangesSpawnPoint.position.y, challangesSpawnPoint.position.z);


        GameObject newChallenge = Instantiate(challenges[Random.Range(0, challenges.Length)], challangesSpawnPoint.position, Quaternion.identity) as GameObject;

        newChallenge.transform.parent = transform;
        counter = 4.0f;

    }





	
	
	}




