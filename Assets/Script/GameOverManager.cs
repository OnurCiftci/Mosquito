using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public Text distancetext;
    public Text cointext;
	// Use this for initialization
	void Start () {
        
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {

        distancetext.text = "" + Mathf.Round(PlayerPrefs.GetFloat("GIDILEN"));
        cointext.text = "" + PlayerPrefs.GetInt("TOPLANILAN");

           }
    
    public void ReturnMenu()
    {

        Application.LoadLevel("StartMenu");

    }

}
