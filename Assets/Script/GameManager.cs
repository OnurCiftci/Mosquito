using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform canvas;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {

			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
                AudioListener.pause = true;
                Time.timeScale = 0;
                

			} else if (canvas.gameObject.activeInHierarchy == true) {

				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
                AudioListener.pause = false;
                

			}

		
		}

	}
	public void LoadLevel(string name)
	{
		Application.LoadLevel (name);




	}
	public void loadlevel()
	{
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;


	}
	public void QuidGame()
	{
		Application.Quit ();


	}



}

		

