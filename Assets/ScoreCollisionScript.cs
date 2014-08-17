using UnityEngine;
using System.Collections;

public class ScoreCollisionScript : MonoBehaviour {
    public GameObject bounceCounter;
    public GameScript gameScript;
	public float y;
	public float x;
	public Transform ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
        FireShotBehavior currentBall = coll.gameObject.GetComponent<FireShotBehavior>();
		currentBall.audio2.Play ();
        gameScript.Score(currentBall.getMultiplier(),currentBall.bounceCount);
		Debug.Log ("Colision"+coll.gameObject.tag);
		Debug.Log ("shotX: " + coll.gameObject.GetComponent<FireShotBehavior>().shotX);
		//coll.gameObject.tag = "Finish";
		//Instantiate (ball, new Vector3 (x, y, 0), Quaternion.identity);
	}
}
