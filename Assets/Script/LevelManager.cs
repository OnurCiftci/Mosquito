using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public AudioSource market;
    public GameObject[] buttons;
	public Transform MainMenu, OptionsMenu,LazerMenu;
	private int laser,laser2;
	public Text laserhave;
	public float highscore1;
	public Text highscore;

	public Text coinhave;
	public Text coincost;
	private int coin;
    private int doublecoin;
	public ScoreManager high;
    private int quickstart;
    private void Awake()
    {
        Debug.Log("kjsfhlsdajfhşdsf");
        PlayerPrefs.SetInt("DOUBLECOIN", 0);
        PlayerPrefs.SetInt("QUICKSTART", 0);
    }

    void Start()
	{
 
		high = FindObjectOfType<ScoreManager> ();
	}


	// Use this for initialization

	public void LoadLevel(string name)
	{

		Application.LoadLevel (name);

	}
	public void QuidGame()
	{
		Application.Quit ();


	}
    public void ReturnStartMenu()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);

        }
        MainMenu.gameObject.SetActive(true);
        OptionsMenu.gameObject.SetActive(false);


    }


	public void OptionMenu(bool click)
	{
        for(int i=0;i< buttons.Length;i++)
        {
            buttons[i].gameObject.SetActive(false);

        }
		if (click == true) {
			MainMenu.gameObject.SetActive (false);
			OptionsMenu.gameObject.SetActive (click);


		} else {
			MainMenu.gameObject.SetActive (true);
			OptionsMenu.gameObject.SetActive (click);


		}


	}



	public void Laserbuy()
	{
        coin = PlayerPrefs.GetInt ("COIN");
		laser = PlayerPrefs.GetInt ("LASERCOUNT");
		if (laser == 0)
			laser2 = 1;
		else
			laser2 = laser;
		if (coin >= 50 * laser2) {
            market.Play();
			coin -= 50 * laser2;
			PlayerPrefs.SetInt ("LASERCOUNT", laser + 5);
			PlayerPrefs.SetInt ("COIN", coin);

		} else {




		}
	}

    public void DoubleCoinBuy()
    {
        doublecoin = PlayerPrefs.GetInt("DOUBLECOIN");
        coin = PlayerPrefs.GetInt("COIN");
        if(coin>=100 && doublecoin==0)
        {
            market.Play();
            coin -= 100;
            PlayerPrefs.SetInt("DOUBLECOIN", 1);
            PlayerPrefs.SetInt("COIN", coin);
        }
        else
        {


        }

    }
    public void QuickStartBuy()
    {
        quickstart = PlayerPrefs.GetInt("QUICKSTART");
        coin = PlayerPrefs.GetInt("COIN");
        if(coin>=250 && quickstart==0)
        {
            market.Play();
            coin -= 250;
            PlayerPrefs.SetInt("QUICKSTART", 1);
            PlayerPrefs.SetInt("COIN", coin);



        }


    }


	public void Update()
	{
		laser = PlayerPrefs.GetInt ("LASERCOUNT");
		laserhave.text = "HAVE:" + laser;
		coin = PlayerPrefs.GetInt ("COIN");
		coinhave.text="COIN:"+coin;
		if (laser == 0)
			laser = 1;
		coincost.text = ""+50 * laser;
		highscore1=PlayerPrefs.GetFloat("HIGHSCORE");
		highscore.text = "Yuksek Skor:" + Mathf.RoundToInt(highscore1);
		
	}








}
