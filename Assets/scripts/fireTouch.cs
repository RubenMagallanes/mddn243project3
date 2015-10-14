using UnityEngine;
using System.Collections;

public class fireTouch : MonoBehaviour {
	public string levelToLoad;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnTriggerEnter ( Collider other) {
		StartCoroutine(TestCoroutine());
		print ("hello!");
	}
	
	IEnumerator TestCoroutine(){
		Debug.Log ("about to yield return WaitForSeconds(1)");
		yield return new WaitForSeconds(1);
		Debug.Log ("Just waited 5 seconds");
		yield return new WaitForSeconds(1);
		Debug.Log ("Just waited another second");
		Application.LoadLevel(levelToLoad);
		yield break;
		Debug.Log ("You'll never see this"); // produces a dead code warning
	}
	
	//Application.LoadLevel(levelToLoad);
	
}

//	function OnCollisionEnter(collision : Collision) { Application.loadLevel("name of the level to be loaded"); }