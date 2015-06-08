using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls all the buttons in the level*/
public class LevelButtonManager : MonoBehaviour {

	//texture for the options button
	public Texture2D optionsTexture;

	//texture for the replay button
	public Texture2D replayTexture;

	//texture for the next button
	public Texture2D nextTexture;

	//texture for the map button
	public Texture2D mapTexture;

	//reference to the options menu image
	public Image menu;

	//reference to the map button inside the options menu
	public Image mapButton;

	//reference to the replay button inside the options menu
	public Image replayButton;

	//reference to the resume button inside the option menu
	public Image resumeButton;

	//determines the size of all the buttons
	public static float button_width;
	public static float button_height;

	//determines which level the player is currently on
	public int level;
	
	//Called when the player interacts with a GUI element
	void OnGUI() {

		//if the screen is in landscape
		if (Screen.width > Screen.height) {

			//set the button sizes appropriately
			button_width = Screen.width / 10;
			button_height = Screen.height / 10;
		} 

		//otherwise the screen is in portrait
		else {

			//set the button sizes appropriately
			button_width = Screen.height / 10;
			button_height = Screen.width / 10;
		}

		//set the location of the replay button
		float replay_xPos = Screen.width / 2 - button_width * 2f;
		float replay_yPos = Screen.height / 2 + button_height;

		//set the location of the map button
		float map_xPos = Screen.width / 2 + button_width;
		float map_yPos = Screen.height / 2 + button_height;

		//set the location of the next button
		float next_xPos = Screen.width / 2 - button_width/2;
		float next_yPos = Screen.height / 2 + button_height/2;

		//set the location of the options button
		float options_xPos = -button_width/20;
		float options_yPos = -button_height/4;

		//if not inside the options menu and there are still people left to save
		if (!PauseMenu.paused && PeopleManager.peopleLeft > 0) {

			//instatiate the options button and if the player clicks it...
			if (GUI.Button (new Rect (options_xPos, options_yPos, button_width * 2, button_height * 2), optionsTexture, GUIStyle.none)) {

				//open the options menu and pause the game
				PauseMenu.paused = true;
				menu.enabled = true;

				//enable the 3 options menu buttons
				mapButton.enabled = true;
				replayButton.enabled = true;
				resumeButton.enabled = true;
			}
		}

		//if the scene is over and there are no people left to save
		if (PeopleManager.peopleLeft == 0) {

			//if the player failed to save the required amount of people
			if(RescueManager.peopleRescued < RescueManager.rescuedCondition){

				//instatiate the replay button and if the player clicks it
				if (GUI.Button(new Rect(replay_xPos, replay_yPos, button_width * 2, button_height * 2), replayTexture, GUIStyle.none)){

					//load the level scene
					Application.LoadLevel(level + 1);
				}

				//instatiate the map button and if the player clicks it
				if (GUI.Button(new Rect(map_xPos, map_yPos, button_width * 2, button_height * 2), mapTexture, GUIStyle.none)) {
					//load the map scene
					Application.LoadLevel(1);
				}
			}

			//if the player managed to save the required amount of people
			if(RescueManager.peopleRescued >= RescueManager.rescuedCondition) {

				//if it isn't the last level
				if(RescueManager.peopleRescued < 75) {

					//instatiate the next button and if the player clicks it
					if (GUI.Button(new Rect(next_xPos, next_yPos, button_width * 2, button_height * 2), nextTexture, GUIStyle.none)) {

						//if the player is in the first scene
						if(RescueManager.peopleRescued <= 30 && !cityScript.lvl1isOver)

							//flag the first scene as complete
							cityScript.lvl1isOver = true;

						//if the player is in the second scene
						if(RescueManager.peopleRescued > 30 && !metroScript.lvl2isOver)

							//flag the second scene as complete
							metroScript.lvl2isOver = true;

						//load the map level
						Application.LoadLevel(1);
					}
				}

				//otherwise the player is in the final level
				else {

					//instatiate the map button and if the player clicks is
					if (GUI.Button(new Rect(next_xPos, next_yPos, button_width * 2, button_height * 2), mapTexture, GUIStyle.none)) {

						//load the map scene
						Application.LoadLevel(1);
					}
				}
			}
		}
	}
}
