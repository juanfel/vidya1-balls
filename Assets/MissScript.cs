using UnityEngine;
using System.Collections;

public class MissScript : MonoBehaviour {
	public float y;
	public float x;
	public Transform ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log ("Miss");
		//coll.gameObject.tag = "Finish";
		//Instantiate (ball, new Vector3 (x, y, 0), Quaternion.identity);
	}
}
