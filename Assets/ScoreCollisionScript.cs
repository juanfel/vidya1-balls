using UnityEngine;
using System.Collections;

public class ScoreCollisionScript : MonoBehaviour {
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
		Debug.Log ("Colision"+coll.gameObject.tag);
		coll.gameObject.tag = "Finish";
		Instantiate (ball, new Vector3 (x, y, 0), Quaternion.identity);
	}
}
