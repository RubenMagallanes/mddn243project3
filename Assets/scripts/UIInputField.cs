using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputField : MonoBehaviour {

	public Text actionText; 
	// Use this for initialization
	void Start () {
		actionText = GameObject.Find ("InputField").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (actionText != null)
			Debug.Log (actionText);
	}

	public void CharacterField(string txt){
		actionText.text = txt;
	}


	public void clickTest (){


		Debug.Log ("clicc");
		//get text from text box
		//clear text boc
		//parse for commands
		//construct objects and give to robot
		//set flag to true so robot executes commands

	}

}
