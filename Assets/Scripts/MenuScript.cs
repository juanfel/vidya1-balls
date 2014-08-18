using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public static int highscore = 0;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width/2-40,Screen.height-60,80,20),"Play")){
			Application.LoadLevel("gameplay");
			this.gameObject.SetActive(false);
		}
	}
}