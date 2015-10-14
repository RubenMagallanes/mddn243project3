using UnityEngine;
using System.Collections;

public class ThirdPersonScript : MonoBehaviour {
	// Use this for initialization

	//public bool RunRight;

	public float gravity = 9.8f;

	//private Animator anim;

	void Start () {
		//anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		//anim = GetComponent<Animator> ();

		if (Input.GetKey (KeyCode.Space)) {
			transform.position = new Vector3 (transform.position.x, transform.position.y+gravity*Time.deltaTime+0.1f,transform.position.z);
		}


		if (Input.GetKey ("right")) {
			transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z );
			//anim = SetBool("RunRight", true);
			//Animation.Play("RunRight");
		
		} else if (Input.GetKey ("left")) {
			transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z );	
		}

	}
}
