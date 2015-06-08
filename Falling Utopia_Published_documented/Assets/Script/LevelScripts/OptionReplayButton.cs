using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the replay button in the options menu*/
public class OptionReplayButton : MonoBehaviour {

	//determines the level the player is on
	public int level;

	//reloads the level the player is currently on and unpauses the game
	public void Replay(){
		Application.LoadLevel (level + 1);
		PauseMenu.paused = false;
	}
}
