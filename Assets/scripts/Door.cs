using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Animator anim; 
	public string levelToLoad;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//Debug.Log ("About to StartCoroutine");
		//Debug.Log ("Back from StartCoroutine");
	}
	
	// Update is called once per frame
	void OnTriggerEnter ( Collider other) {
		StartCoroutine(TestCoroutine());
		print ("hello!");
		anim.SetBool ("DoorOpen", true);
		anim.SetBool ("DoorClose", false);
	}

	IEnumerator TestCoroutine(){
		Debug.Log ("about to yield return WaitForSeconds(1)");
		yield return new WaitForSeconds(0);
		Debug.Log ("Just waited 5 seconds");
		yield return new WaitForSeconds(1);
		Debug.Log ("Just waited another second");
		Application.LoadLevel(levelToLoad);
		yield break;
		Debug.Log ("You'll never see this"); // produces a dead code warning
	}

	void OnTriggerExit (Collider other){
		anim.SetBool ("DoorOpen", false);
		anim.SetBool ("DoorClose", true);

		//Application.LoadLevel(levelToLoad);

}

//	function OnCollisionEnter(collision : Collision) { Application.loadLevel("name of the level to be loaded"); }
}
