using UnityEngine;
using System.Collections;

public class BounceCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		//Cuenta cuantas veces un jugador salta
		if (coll.gameObject.tag == "Player") 
		{
			coll.gameObject.GetComponent<FireShotBehavior>().bounceCount += 1;
		}
	}
}
