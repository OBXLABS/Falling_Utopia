using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*This class controls the tutorial functions and determines when they should be displayed*/
public class TutorialScript : MonoBehaviour {

	//determines whether the tutorial is on or not
	public static bool tutorialOn = true;

	//reference to the text for the next icon
	public Text nextText;

	//flags whether the tutorial can close or not (simply for timing)
	bool canClose = false;

	// Update is called once per frame
	void Update () {

		//if the player can close the tutorial
		if (canClose){

			//if the player clicks on the screen
			if (Input.GetButtonDown ("Fire1")) {

				//turn off the tutorial
				tutorialOn = false;

				//While playing the first level
				//if the first level is not over then set the the first visit to false for the village script
				//so that the animation will be stopped and the map position will be displayed
				if(!cityScript.lvl1isOver)
					villageScript.firstVisit = false;

				//if level 1 is over also set first visit to false in the city script
				if(cityScript.lvl1isOver)
					cityScript.firstVisit = false;
			
				
				//if level 2 is over also set first visit to false in the metro script
				//this script is not recognized where is the level 2 set to true?
				if(metroScript.lvl2isOver)
					metroScript.firstVisit = false;

			}
		}

		//if the first level is not beaten
		if (!cityScript.lvl1isOver) {

			//and iff the tutorial is not on or it is not the first visit to the first level
			if (!tutorialOn || !villageScript.firstVisit) {

				//turn off the tutorial and destroy the object
				tutorialOn = false;
				Destroy (this.gameObject);
			}
		} 

		//otherwise the first level is beaten
		else {

			//if the second level is not beaten
			if (!metroScript.lvl2isOver) {

				//and if the tutorial is off or it is not the first visit to the seconf level
				if (!tutorialOn || !cityScript.firstVisit) {

					//turn off the tutorial and destroy the object
					tutorialOn = false;
					Destroy (this.gameObject);
				}
			}

			//otherwise the second level is beaten
			else {

				//if the tutorial is not on or it is not the first visit to the third level
				if (!tutorialOn || !metroScript.firstVisit) {

					//turn off the tutorial and destroy the object
					tutorialOn = false;
					Destroy (this.gameObject);
				}
			}
		}
	}

	//allows the player to close the tutorial
	public void stopTutorial() {
		canClose = true;
		nextText.enabled = true;
	}
}
