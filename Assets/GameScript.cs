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
	public GUIText multiplier_label;
	public GUIText turn_label;
	public GUIText round_label;
	public Transform ball;

	int score1 = 0;
	int score2 = 0;
	int score3 = 0;

	int round = 0;

	// Use this for initialization
	void Start () {
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

	public void nextTurn(){

		if (turn % 3 == 2) {
			round++;
		}
		// al final de la ronda 7, terminar el juego
		if (round >= 7) {
			endGame();
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
			decimal mult = (decimal)(Mathf.Abs ((0 - ball.position.x)*0.25f)+1);
			multiplier_label.text = mult.ToString("F2");
		}
		round_label.text = (round+1).ToString ();
		turn_label.text = ((int)((turn % 3) + 1)).ToString();
		timer_label.text = time.ToString();
		score1_label.text = score1.ToString();
		score2_label.text = score2.ToString();
		score3_label.text = score3.ToString();
	}
}
