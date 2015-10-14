using UnityEngine;
using System.Collections;

public class ThirdPersonScript : MonoBehaviour {
	// Use this for initialization

	//public bool RunRight;

	public float gravity = 9.8f;
	public string command = "";
	public string option = "";
	public bool hasCommandTodo = true;

	private int framesLeft = 0; 
	//private Animator anim;

	void Start () {
		//anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (framesLeft == 0) {
			command = "";
			option = "";
			hasCommandTodo = false;
		}

		//anim = GetComponent<Animator> ();

		if (command != "") {
			Debug.Log(command);
		}
		if (Input.GetKey (KeyCode.Space)) {

		}

		if (hasCommandTodo) {
			framesLeft --;
			if (command == "move") {
				if (option == "right") {
					transform.position = new Vector3 (transform.position.x + 0.3f, transform.position.y, transform.position.z);
				
					//anim = SetBool("RunRight", true);
					//Animation.Play("RunRight");
				} else if (option == "left") {
					//move left
					transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y, transform.position.z);
				}

			} else if (command == "jump") {
				if (option == "right") {
					print ("jumpright");
					transform.position = new Vector3 (transform.position.x + 0.3f, transform.position.y + 0.3f, transform.position.z);
					//jump right
				} else if (option == "left") {
					//jump left
					transform.position = new Vector3 (transform.position.x - 0.3f, transform.position.y + 0.3f, transform.position.z);
				}
			}
		}
	}

	public void giveCommand(string cmd, string opt){
		this.command = cmd;
		this.option = opt;
		this.hasCommandTodo = true;
		this.framesLeft = 24;
	}
}
