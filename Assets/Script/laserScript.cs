using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	LineRenderer laserLine;
	public GameObject obje;
	public Vector2 pos;
	public bool fire;
	public int leftlaser;
	 Scroller scrl;
	public GameObject lazer;

	public GameObject sinek;




	private WaitForSeconds duration = new WaitForSeconds (0.1f);
	// Use this for initialization
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (.2f, .2f);
		fire = true;
		laserLine.enabled = false;
		scrl = FindObjectOfType<Scroller> ();
		lazer.gameObject.SetActive (false);



	}
	// Update is called once per frame
	void Update () {

		lazer.transform.position = new Vector3 (1.11f, sinek.transform.position.y, sinek.transform.position.z);
		leftlaser = scrl.leftlaser;
		pos = new Vector2 (9.1f, obje.transform.position.y);
		if (Input.GetKeyDown (KeyCode.F) && leftlaser>=0  ) {
			FireLaser ();
		}
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, pos);


		}

	void CanFire()
	{
		fire = true;


	}
	void TurnOfLaser()
	{
		laserLine.enabled = false;
		lazer.gameObject.SetActive (false);
	
	}
	void FireLaser()
	{
		if (fire) {
            AudioSource las = GetComponent<AudioSource>();

            las.Play();
			lazer.gameObject.SetActive (true);
			laserLine.enabled = true;
			fire = false;
			Invoke ("TurnOfLaser", .1f);
			Invoke ("CanFire", .1f);

		}


	}

}
