using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour {
	public string levelToLoad;
	public void Update() {
		if (Input.GetMouseButton (0) == true) {
			Debug.Log ("Pressed left click.");
			print ("sksjflekk");
			Application.LoadLevel (levelToLoad);
		}
	}
}