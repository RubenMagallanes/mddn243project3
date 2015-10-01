using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter(Collider other){
		GameManager.completeLevel ();

	}
	// Update is called once per frame
	void Update () {
	
	}
}
