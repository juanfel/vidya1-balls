using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

	public GUIText High;

	void Start(){

		High.text = "Highscore: " + MenuScript.highscore.ToString ();

	}
}
