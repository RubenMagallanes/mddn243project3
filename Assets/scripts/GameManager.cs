using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int currentLevel =0;
	public static int unlockedLevel =0;

	public static ArrayList actions ;
	public static bool listReady = false;

	void Start(){
		GameManager.actions = new ArrayList ();
		GameManager.populateActions ();

	}

	public static void completeLevel(){
		//maybe add stuff in here 
		Application.LoadLevel ( ++currentLevel );//loads next lvl
	}

	private static void populateActions(){
		//pre: actions exists
		if (GameManager.currentLevel == 0) {
			GameManager.actions.Add (new playerController.Action ("move"));
		} //adds more depending on level

		GameManager.listReady = true;
		//post: list of level's actions ready, filled
	}



}
