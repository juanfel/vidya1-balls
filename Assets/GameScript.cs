using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	
	public int time = 500;
	public int turn = 1;
    int multiplier;
	public GUIText timer_label;
	public GUIText score1_label;
	public GUIText score2_label;
	public GUIText score3_label;
	public GUIText multiplier_label;
	public GUIText turn_label;
	public Transform ball;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Timer", 0, 1);
	}

	void Timer(){
		time--;
	}

	public void Score(float distanceMultiplier, float bounces){
        score1_label.text = (100 * distanceMultiplier * (bounces+1)).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (!ball.GetComponent<FireShotBehavior> ().launched) {
						multiplier_label.text = 
						(Mathf.Abs ((0 - ball.position.x)*0.25f)+1).ToString ();
				}
		timer_label.text = time.ToString();
	}
}
