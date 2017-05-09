using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour {
    public AudioSource coinsound,enemysound;
    public float wingforce = 10.0f;
    public float flyforce = 5.0f;
    Rigidbody2D RGB;
    bool isGrounded = false;
	public Text cointext;
	public int coin;
	int phealth;
	public GameObject heart1,heart2,heart3;
    public int toplanilancoin;
    private int increasecoin;
	// Use this for initialization
	void Start () {
        toplanilancoin = 0;
        AudioListener.pause = false;
        coin =PlayerPrefs.GetInt ("COIN");
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}


        RGB = transform.GetComponent < Rigidbody2D >();
		phealth = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded != true)
         RGB.AddForce(Vector3.up * (wingforce * RGB.mass * RGB.gravityScale * 20.0f));
		if (Input.GetKey (KeyCode.Space) && isGrounded != true) {
			RGB.AddForce (Vector3.up * (flyforce * RGB.mass * RGB.gravityScale * 5.0f));

		}
        if(PlayerPrefs.GetInt("DOUBLECOIN")==1)
        {
            increasecoin = 10;
        }
        else
        {
            increasecoin = 5;

        }

        //Debug.Log(increasecoin);


		cointext.text = "Coin:" + coin;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.collider.tag == "Ground") {
            Application.LoadLevel("gameover");
			//phealth--;
			isGrounded = true;
			//Application.LoadLevel ("StartMenu");

		} else if (collision.collider.tag == "BonusTaker") {
            
            coinsound.Play();
			Destroy (collision.gameObject);
			coin += increasecoin;
            toplanilancoin += increasecoin;

            PlayerPrefs.SetInt ("COIN", coin);
		
			cointext.text = "Coin:" + coin;
		} else if (collision.collider.tag == "enemy"|| collision.collider.tag == "sarma") {
            enemysound.Play();
            Destroy (collision.gameObject);
			phealth--;
            
			if (phealth == 2) {
				Destroy (heart1.gameObject);
			} else if (phealth == 1) {
				Destroy (heart2.gameObject);
			} else if (phealth == 0) {
				Destroy (heart3.gameObject);
                
				Application.LoadLevel ("gameover");
			}
				

		}

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
    }



}
