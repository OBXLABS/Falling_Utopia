using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the map button in the options menu*/
public class OptionGoToMapButton : MonoBehaviour {

	//sends the player to map map screen and unpauses the game
	public void OptionGoToMap(){
		Application.LoadLevel(1);
		PauseMenu.paused = false;
	}
}
