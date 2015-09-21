using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int currentLevel =0;
	public static int unlockedLevel;

	public static void completeLevel(){
		Application.LoadLevel ( ++currentLevel );//loads next lvl
	}
}
