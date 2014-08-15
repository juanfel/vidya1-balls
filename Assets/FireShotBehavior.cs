using UnityEngine;
using System.Collections;

public class FireShotBehavior : MonoBehaviour {

	// Use this for initialization
	public float x;
	public float y;
	public Transform ball;
	public int bounceCount;
	Vector2 forceVector = new Vector2(1,0);
	Quaternion angleQuat;
	float anglenum = 0f;
	bool launched = false;
	float power = 0f;
	void Start () {
		forceVector = new Vector2(1,0);
		launched = false;
		power = 0f;
		anglenum = 0f;
		bounceCount = 0;
		rigidbody2D.isKinematic = true;
	}
	void createNewBall()
	{
		Instantiate (ball, new Vector3 (x, y, 0), Quaternion.identity);
	}
	// Update is called once per frame
	void Update () {
		if (!launched) {
						//Queremos que al disparar una pelota se cree una nueva dentro de un tiempo, y se elimine despues
						//un tiempo mas grande
						if (Input.GetButtonUp ("Fire1") == true && rigidbody2D.isKinematic) {
								rigidbody2D.isKinematic = false;
								angleQuat = Quaternion.AngleAxis (anglenum, Vector3.forward);
								rigidbody2D.AddForce (angleQuat * forceVector * power, ForceMode2D.Impulse);
				                launched = true;
							Invoke ("createNewBall",1f);
							Destroy(gameObject,10f);
						}
						if (Input.GetButton ("Fire1") == true && rigidbody2D.isKinematic) {
							power = power + 0.1f;
						}
						float movement = Input.GetAxis ("Horizontal");
						if (movement != 0) {

								Vector3 currentPos = transform.position;
								currentPos.x = currentPos.x + (movement) * 0.1f;
								if(currentPos.x >= 0)
								{
									currentPos.x = 0;
								}
								transform.position = currentPos;

						}
						float angleAxis = Input.GetAxis ("Vertical");
						if (angleAxis != 0) {
								anglenum += 0.1f*Mathf.Sign (angleAxis); 
						}
		}
	}
}
