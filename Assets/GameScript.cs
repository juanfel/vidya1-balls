using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	
	public int time = 500;
	public int turn = 0;
    int multiplier;
	public GUIText timer_label;
	public GUIText score1_label;
	public GUIText score2_label;
	public GUIText score3_label;

	public GUIText powerup1_label;
	public GUIText powerup2_label;
	public GUIText powerup3_label;

	public GUIText multiplier_label;
	public GUIText turn_label;
	public GUIText round_label;
	public Transform ball;
	public Transform powerup;

	int score1 = 0;
	int score2 = 0;
	int score3 = 0;

	public int[] powerups = new int[3];


	int round = 0;

	// Use this for initialization
	void Start () {
		for (int x=0; x<3; x++) {
			powerups[x] = 0;
		}
		InvokeRepeating ("Timer", 0, 1);
	}

	void Timer(){
		time--;
	}

	public void Score(float distanceMultiplier, float bounces,int ball_turn){
		if (ball_turn % 3 == 0)
			score1 += (int)(100 * distanceMultiplier * (bounces + 1));
		if (ball_turn % 3 == 1)
			score2 += (int)(100 * distanceMultiplier * (bounces + 1));
		if (ball_turn % 3 == 2)
			score3 += (int)(100 * distanceMultiplier * (bounces + 1));
	}

	public void spawnPowerUp (){
		if (GameObject.FindGameObjectsWithTag ("powerup").Length == 0) {
				int x = Random.Range (-8, 7);
				int y = Random.Range (2, 6);
				Object d = Instantiate (powerup, new Vector3 (x, y, 0), Quaternion.identity);
				((Transform)d).GetComponent<PowerUpCollisionScript>().gameScript = this;
		}
	}

	public void givePowerUp(int ball_turn){
		powerups [ball_turn % 3]++;
	}

	public void nextTurn(){

		if (turn % 3 == 2) {
			round++;

		}
		// al final de la ronda 7, terminar el juego
		if (round >= 7) {
			endGame();
		}
		if (turn % 2 == 1) {
			spawnPowerUp();
		}
		turn++;
	}

	private void endGame(){

		// ir a la pantalla de gameover, highscore...
	}
	
	// Update is called once per frame
	void Update () {
		if (!ball.GetComponent<FireShotBehavior> ().launched) 
		{
			decimal mult;
			if(ball.GetComponent<FireShotBehavior>().poweredup)
				mult = (decimal)(Mathf.Abs ((0 - ball.GetComponent<FireShotBehavior>().shotX)*0.25f)+1);
			else
				mult = (decimal)(Mathf.Abs ((0 - ball.position.x)*0.25f)+1);
			multiplier_label.text = mult.ToString("F2");
		}
		round_label.text = (round+1).ToString ();
		turn_label.text = ((int)((turn % 3) + 1)).ToString();
		timer_label.text = time.ToString();
		score1_label.text = score1.ToString();
		score2_label.text = score2.ToString();
		score3_label.text = score3.ToString();

		powerup1_label.text = powerups [0].ToString ();
		powerup2_label.text = powerups [1].ToString ();
		powerup3_label.text = powerups [2].ToString ();
	}
}
