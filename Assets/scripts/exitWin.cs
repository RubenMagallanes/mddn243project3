using UnityEngine;
using System.Collections;



public class exitWin : MonoBehaviour {

	string levelToLoad;

	public void OnTriggerEnter (Collider hit){
		Application.LoadLevel(levelToLoad);
	}
}
