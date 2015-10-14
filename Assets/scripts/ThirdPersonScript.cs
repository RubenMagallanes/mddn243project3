using UnityEngine;
using System.Collections;

public class ThirdPersonScript : MonoBehaviour {
	// Use this for initialization

	//public bool RunRight;

	public float gravity = 9.8f;
	public string command = "";
	public string option = "";
	public bool hasCommandTodo = false;

	//private Animator anim;

	void Start () {
		//anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		//anim = GetComponent<Animator> ();

		if (command != "") {
			Debug.Log(command);
		}
		if (Input.GetKey (KeyCode.Space)) {
			transform.position = new Vector3 (transform.position.x, transform.position.y+gravity*Time.deltaTime+0.1f,transform.position.z);
		}


		if (Input.GetKey ("right")) {
			//transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z );
			//anim = SetBool("RunRight", true);
			//Animation.Play("RunRight");
		
		} else if (Input.GetKey ("left")) {
			//transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z );	
		}

	}

	public void giveCommand(string cmd, string opt){
		this.command = cmd;
		this.option = opt;
		this.hasCommandTodo = true;
	}
}
