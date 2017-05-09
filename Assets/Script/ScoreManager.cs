using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public float generalcounter;
	public Text scoreText;

	public float highscoreCount;

	public float scoreCount;
    public int coin;
	public float pointsPerSecond;
	public bool scoreIncreasing;
    public PlayerMove score;
    public Scroller scrollerspeed;
	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(this);
        
        scoreCount = 0;
		highscoreCount = PlayerPrefs.GetFloat ("HIGHSCORE");
        score = FindObjectOfType<PlayerMove>();
        scrollerspeed = FindObjectOfType<Scroller>();
	}
	
	// Update is called once per frame
	void Update () {
        coin = score.toplanilancoin;
        PlayerPrefs.SetInt("TOPLANILAN", coin);
		if (scoreCount >= highscoreCount) {
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HIGHSCORE" ,highscoreCount);
		}
		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
        PlayerPrefs.SetFloat("GIDILEN", scoreCount);
        generalcounter = scoreCount / 40000;
        if (scrollerspeed.scrollSpeed < 12)
        {
            scrollerspeed.scrollSpeed = generalcounter + scrollerspeed.scrollSpeed;
        }
       

          scoreText.text = "Score:" + Mathf.Round(scoreCount);

	}
}
