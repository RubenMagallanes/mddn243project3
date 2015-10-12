using UnityEngine;
using System.Collections;

public class falloutdeath : MonoBehaviour {

	public int lives = 5;
	public Transform respawn;
	public Transform fallout;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.transform == fallout) {
			transform.position = respawn.position;
			lives -= 1;
		}
	}
}
