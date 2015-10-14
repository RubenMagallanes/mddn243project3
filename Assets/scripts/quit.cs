using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	public void Update() {
		if (Input.GetMouseButton (0) == true) {
			Debug.Log ("Pressed left click.");
			print ("gggdfdf");
			Application.Quit();
		}
	}
}
