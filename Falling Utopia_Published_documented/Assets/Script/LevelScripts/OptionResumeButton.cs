using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the resume button in the options menu*/
public class OptionResumeButton : MonoBehaviour {

	//reference to the options menu image
	public Image menu;

	//references to each button image on in the options menu
	public Image mapButton;
	public Image replayButton;
	public Image resumeButton;

	//resumes the game and unpauses the game
	public void Resume(){

		//disables all options menu functions
		PauseMenu.paused = false;
		menu.enabled = false;
		mapButton.enabled = false;
		replayButton.enabled = false;
		resumeButton.enabled = false;
	}
}
