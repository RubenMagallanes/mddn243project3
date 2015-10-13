using UnityEngine;
using UnityEngine.UI;
using System;

public class TechnoPsychic : MonoBehaviour {
	
	public GameObject terminalCanvas;
	public GameObject output;
	public GameObject input;
	
	Text terminalText;
	
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		player = FindObjectOfType<PlayerController> ();
		
		terminalText = output.GetComponent<Text> ();
		
		playerInRange = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	private void OnTriggerEnter2D (Collider2D other) {
		if(other.name == "player") {
			playerInRange = true;
		}
	}
	
	public void OnTriggerExit2D (Collider2D other) {
		if(other.name == "player") {
			playerInRange = false;
		}
	}
	
	// =================
	// TERMINAL COMMANDS
	// =================
	
	public void ParseCommand(string cmd) {
		// can't manage to clear text field
		cmd = cmd.Replace (System.Environment.NewLine, ""); // get rid of newlines from ENTER
		terminalText.text += " [" + cmd + "]"; // show what the player typed in
		cmd = cmd.ToLower (); // convert all text to lowercase
		string[] keywords = cmd.Split (' '); // split the text up by spaces
		
		if (keywords.Length == 0 || keywords [0].Length < 4) {
			CommandNotRecognised();
		} else if (keywords.Length == 1) {
			if (keywords [0][0] == '?') {
				HelpCommand (keywords [0]);
			} else {
				Command (keywords [0], null);
			}
		} else if (keywords.Length == 2) {
			Command (keywords [0], keywords [1]);
		} else {
			CommandNotRecognised();
		}
		
		PromptLine();
	}
	
	private void Command(string program, string modifier) {
		string filename = program.Substring (0, program.Length - 4);
		string extension = program.Substring (program.Length - 4);
		
		if (extension == ".exe") {
			if (filename == "dash") {
				terminalText.text += "\n" + "[DASH.exe ACTIVATED]";
			} else if (filename == "emp") {
				terminalText.text += "\n" + "[EMP.exe ACTIVATED]";
			} else if (filename == "drone") {
				
			} else {
				CommandNotRecognised ();
			}
		} else if (extension == ".bat") {
			if (filename == "dim" && dimActive) {
				terminalText.text += "\n" + "[DIM.bat ACTIVATED]";
				terminalText.text += "\n" + "Lights will be disabled for [5] seconds.";
				StartCoroutine (levelManager.Lights ());
			} else if (filename == "drone" && droneActive) {
				if(!player.drone.activate()) {
					terminalText.text += "\n" + "[ERROR] Drone not yet deployed.";
				} else {
					terminalText.text += "\n" + "DroneCam Activated";
					levelManager.terminalLive = false;
				}
			} else {
				CommandNotRecognised ();
			}
		} else if (extension == ".reg") {
			if (filename == "speed") {
				terminalText.text += "\n" + "[SPEED.reg ACTIVATED]";
			} else {
				CommandNotRecognised ();
			}
		} else if (extension == ".txt") {
			if (filename == "evac" && levelManager.CheckPickedUp("EVAC.txt")) {
				terminalText.text += "\n\n" + "You're probably very confused right now." +
					" Don't be. There's only three things that you need to know." +
						"\n\n" + "1. You're in South City right now." +
						"\n" + "2. You lost your files and you're going to need them back." +
						"\n" + "3. You don't want to be seen by any of the guards." +
						"\n\n" + "You'll need to get through that door up there to the right," +
						" but it doesn't look like the guard is going to move. Try running 'DIM.bat'" +
						" to turn off that light above him, then sneak past. Good luck.";
			} else if (filename == "secret" && levelManager.CheckPickedUp("SECRET.txt")) {
				terminalText.text += "\n\n" + "NEVER GONNA GIVE YOU UP," +
					"\nNEVER GONNA LET YOU DOWN," +
						"\nNEVER GONNA RUN AROUND AND" +
						"\nDESERT YOU";
			} else {
				CommandNotRecognised ();
			}
		} else {
			CommandNotRecognised();
		}
	}
	
	private void HelpCommand(string program) {
		string keyword = program.Substring (1);
		
		if (keyword == "help" || keyword == "") {
			// all FILE USAGE
			
			terminalText.text += "\n\n" + "Enter the name of a .exe file to activate or deactivate the ability.";
			terminalText.text += "\n" + "Type ?exe for a full list of available .exe files.";
			
			terminalText.text += "\n\n" + "Enter the name of a .bat file to trigger the effect of the program.";
			terminalText.text += "\n" + "Type ?bat for a full list of available .bat files.";
			
			terminalText.text += "\n\n" + "Enter the name of a .reg file to install the program.";
			terminalText.text += "\n" + "Type ?reg for a full list of available .reg files.";
		} else if (keyword == "exe") {
			// .exe FILE DESCRIPTIONS
			
			terminalText.text += "\n\n" + "[DASH.exe] - Gives you a sharp but temporary speed boost.";
			terminalText.text += "\n" + "Cooldown time: 5s";
			
			terminalText.text += "\n\n" + "[EMP.exe] - Disables regular guards for 5s.";
			terminalText.text += "\n" + "Cooldown time: 60s";
			
			terminalText.text += "\n\n" + "[DRONE.exe] - Deploys drone a your position using SPACEBAR.";
			terminalText.text += "\n" + "Cooldown time: N/A";
		} else if (keyword == "bat") {
			// .bat FILE DESCRIPTIONS
			
			terminalText.text += "\n\n" + "[DIM.exe] - Turns off the lights for five seconds (guards will not detect you).";
			terminalText.text += "\n" + "Modifier: Delay time in seconds (e.g. 'dim.exe 5' will activate after 5 seconds)";
		} else if (keyword == "reg") {
			// .reg FILE DESCRIPTIONS
			
			terminalText.text += "\n\n" + "[SPEED.reg] - Increases your movement speed.";
			terminalText.text += "\n" + "Currently: DEACTIVATED";
		} else {
			CommandNotRecognised();
		}
	}
	
	private void CommandNotRecognised() {
		terminalText.text += "\n" + "ERROR: Command not recognised.";
		terminalText.text += "\n" + "Type '?help' for a full list of commands.";
	}
	
	private void PromptLine() {
		terminalText.text += "\n\n" + ">_";
	}
	
	private void PlayRecognised() {
		terminalCanvas.GetComponent<AudioSource> ().Play ();
	}
}
