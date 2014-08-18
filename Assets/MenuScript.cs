using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width/2-40,Screen.height-60,80,20),"Play")){
			Application.LoadLevel("gameplay");
		}
	}
}