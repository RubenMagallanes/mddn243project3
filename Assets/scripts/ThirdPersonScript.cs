using UnityEngine;
using System.Collections;

public class ThirdPersonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKey ("right")) {
			transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z );
		
		} else if (Input.GetKey ("left")) {
			transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z );
			
		}
	}
}
