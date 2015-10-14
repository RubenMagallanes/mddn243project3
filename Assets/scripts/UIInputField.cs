using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputField : MonoBehaviour {

	//public Text actionText; 
	// Use this for initialization
	void Start () {
		//actionText = GameObject.Find ("InputField").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (actionText != null)
			//Debug.Log (actionText);
	}

	public void CharacterField(string txt){
		//actionText.text = txt;
	}
	 
	//===========================
	private string command; // string to be parsed through
	//===========================

	public void clickTest (){

		//InputField inputField = (InputField) GameObject.Find("InputField");

		GameObject cnv = GameObject.Find("InputField");
		InputField inputField = cnv.GetComponent<InputField> ();


		command = inputField.text; // save commands
		inputField.text = "";	//clear inputfield
		if (! parseCmnds ()){
			Debug.Log("error");
			Debug.Log(command);
		}

		//parse for commands
		//construct objects and give to robot
		//set flag to true so robot executes commands

	}

	private bool parseCmnds(){

		while (command != "") {
			Debug.Log ("attepting to parse: " + command);
			if (command.StartsWith ("move") || command.StartsWith ("Move")) {
				return parseMove ();
			} else if (command.StartsWith("jump") || command.StartsWith("Jump")){
				return parseJump();
			}
		}

		return false;

	}
	private bool parseMove(){
		gobble ("move");

		bool l=false, r = false; 

		if (!gobble ("("))
			return false;
		if (gobble ("left")) { // try left
			l = true;
		} else if (gobble ("right")){ // try right
			r = true;
		}
		
		if (!(l || r))
			return false;
		if (!gobble (")"))
			return false;

		GameObject player = GameObject.FindWithTag("Player");
		//ThirdPersonScript otherScript = GetComponent<ThirdPersonScript>();
		//Debug.Log ("");
		if (r)
			player.GetComponent<ThirdPersonScript> ().giveCommand ("move", "right");
			
		else 
			player.GetComponent<ThirdPersonScript> ().giveCommand ("move", "left");
			
		Debug.Log ("r, l" + r + ", " + l);
		return true;	

	}
	
	private bool parseJump(){
		gobble ("jump");
		
		bool l=false, r = false; 
		
		if (!gobble ("("))
			return false;
		if (gobble ("left")) { // try left
			l = true;
		} else if (gobble ("right")){ // try right
			r = true;
		}
		
		if (!(l || r))
			return false;
		if (!gobble (")"))
			return false;
		
		GameObject player = GameObject.FindWithTag("Player");
		//ThirdPersonScript otherScript = GetComponent<ThirdPersonScript>();
		//Debug.Log ("");
		if (r)
			player.GetComponent<ThirdPersonScript> ().giveCommand ("jump", "right");
		
		else 
			player.GetComponent<ThirdPersonScript> ().giveCommand ("jump", "left");
		
		Debug.Log ("r, l" + r + ", " + l);
		return true;	
		
	}



	/*
	 *checks for string toEat, removed from the frint of the string command if it is contained 
	 */
	private bool gobble(string toEat){
		if (command.StartsWith (toEat)) {
			command = command.Remove (0, toEat.Length);
			return true;
		} else {
			return false;
		}
	}
}
