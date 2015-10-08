using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Animator anim; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter ( Collider other) {
		print ("hello!");
		anim.SetBool ("DoorOpen", true);
		anim.SetBool ("DoorClose", false);
	}

	void OnTriggerExit (Collider other){
		anim.SetBool ("DoorOpen", false);
		anim.SetBool ("DoorClose", true);
	}
	
}
