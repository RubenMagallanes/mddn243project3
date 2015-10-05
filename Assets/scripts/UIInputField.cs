using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInputField : MonoBehaviour {

	public Text actionText; 
	// Use this for initialization
	void Start () {
		actionText = GameObject.Find ("commands").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CharacterField(string txt){
		actionText.text = txt;
	}
}
