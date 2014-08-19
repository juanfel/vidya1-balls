using UnityEngine;
using System.Collections;

public class PowerUpCollisionScript : MonoBehaviour {
    public GameScript gameScript;
	public float y;
	public float x;
	public Transform ball;
	// Use this for initialization
	void Start () {
		gameObject.tag = "powerup";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
        FireShotBehavior currentBall = coll.gameObject.GetComponent<FireShotBehavior>();
		currentBall.audio3.Play ();
		gameScript.givePowerUp (coll.gameObject.GetComponent<FireShotBehavior> ().getTurn ());
		Destroy(gameObject,0f);

		Debug.Log ("Colision"+coll.gameObject.tag);
		Debug.Log ("shotX: " + coll.gameObject.GetComponent<FireShotBehavior>().shotX);
		//coll.gameObject.tag = "Finish";
		//Instantiate (ball, new Vector3 (x, y, 0), Quaternion.identity);
	}
}
