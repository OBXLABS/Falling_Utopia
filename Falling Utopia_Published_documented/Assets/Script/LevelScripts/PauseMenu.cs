using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the pause function and resets the pause state of the game on loading of scene*/
public class PauseMenu : MonoBehaviour {

	//public boolean that controls the pause state of the game
	public static bool paused;

	// unpauses the game whenever the script is first called on a scene
	void Awake () {
		paused = false;
	}
}
