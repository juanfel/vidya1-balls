using UnityEngine;
using System.Collections;

public class FireShotBehavior : MonoBehaviour {

	// Use this for initialization
	public float x; //Guardan la posicion inicial donde aparece una pelota nueva
	public float y;
	public float shotX; //Guardan la posicion inicial del tiro
	public float shotY;
	public Transform target;
	public Transform power_meter;
	public Transform ball;
	public int bounceCount;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource audio3;
	public Camera GameCamera;
	Vector2 forceVector = new Vector2(1,0);
	Quaternion angleQuat;
	float anglenum = 0f;
	public bool launched = false;
	public bool poweredup = false;
	bool used = false;
	float power = 0f;
	int turn;
	bool oldinstance = false;

	void Start () {
		forceVector = new Vector2(1,0);
		launched = false;
		poweredup = false;
		used = false;
		power = 0f;
		anglenum = 0f;
		bounceCount = 0;
		rigidbody2D.isKinematic = true;
		GameCamera.GetComponent<GameScript> ().ball = this.GetComponent<Transform>();
		turn = GameCamera.GetComponent<GameScript> ().turn;
	}

	void Launch(){
		audio1.Play ();
		rigidbody2D.isKinematic = false;
		angleQuat = Quaternion.AngleAxis (anglenum, Vector3.forward);
		rigidbody2D.AddForce (angleQuat * forceVector * power, ForceMode2D.Impulse);
		launched = true;
		if (!poweredup) {
						shotX = transform.position.x;
						shotY = transform.position.y;
				}
		turn = GameCamera.GetComponent<GameScript> ().turn;
		Invoke ("createNewBall",2f);
		Invoke ("destroyMe", 10f);
	}

	void destroyMe(){
		Destroy (gameObject);
	}
	void createNewBall()
	{
		oldinstance = true;
		Instantiate (ball, new Vector3 (x, y, 0), Quaternion.identity);
		GameCamera.GetComponent<GameScript> ().nextTurn ();
	}
    public float getMultiplier()
    {
        return 0.25f * Mathf.Abs(0 - shotX) + 1;

    }

	public int getTurn()
	{
		return turn;
	}
	// Update is called once per frame
	void Update () {
		if (!launched) {
						//Queremos que al disparar una pelota se cree una nueva dentro de un tiempo, y se elimine despues
						//un tiempo mas grande
						if (Input.GetButtonUp ("Fire1") == true && rigidbody2D.isKinematic) {
								Launch ();
						}
						if (Input.GetButton ("Fire1") == true && rigidbody2D.isKinematic) {
								power = power + 0.25f;
						}
						float movement = Input.GetAxis ("Horizontal");
						if (movement != 0&& !poweredup) {

								Vector3 currentPos = transform.position;
								currentPos.x = currentPos.x + (movement) * 0.1f;
								if (currentPos.x >= 0) {
										currentPos.x = 0;
								}
								if (currentPos.x <= -12) {
										currentPos.x = -12;
								}
								transform.position = currentPos;

						}
						float angleAxis = Input.GetAxis ("Vertical");
						if (angleAxis != 0) {
								anglenum += 0.25f * Mathf.Sign (angleAxis); 
						}
						if (power >= 23) {
								Launch ();
						}
				} 
		else {

			if(Input.GetButtonDown("Fire2") == true && !used && GameCamera.GetComponent<GameScript> ().powerups[turn%3]>0 && !oldinstance){
				GameCamera.GetComponent<GameScript> ().powerups[turn%3]--;
				poweredup = true;
				used = true;
				rigidbody2D.isKinematic = true;
				power = 0;
				CancelInvoke("createNewBall");
				CancelInvoke("destroyMe");
				rigidbody2D.velocity = Vector3.zero;
				launched = false;
			}
		}

		target.eulerAngles = new Vector3 (0, 0, anglenum);
		power_meter.eulerAngles = new Vector3 (0, 0, anglenum);
		power_meter.localScale = new Vector3 (power*0.2f, 1, 1);

        if (!launched)
        {
            target.position = transform.position + new Vector3(0, 0, 3);
            power_meter.position = transform.position + new Vector3(0, 0, 4);
        }

	}
}
