using UnityEngine;
using System.Collections;

/*This class controls which scene the player is sent to when they click a map icon*/
public class mapScript : MonoBehaviour {

	//sends the player to the first level and starts the tutorial
	void goToVillageLevel(){
		TutorialScript.tutorialOn = true;
		Application.LoadLevel (2);
	}

	//sends the player to the second level and starts the tutorial
	void goToCityLevel(){
		if (cityScript.lvl1isOver) {
			TutorialScript.tutorialOn = true;
			Application.LoadLevel (3);
		}
	}

	//sends the player to the third level and starts the tutorial
	void goToMetroLevel(){
		if (metroScript.lvl2isOver) {
			TutorialScript.tutorialOn = true;
			Application.LoadLevel (4);
		}
	}

}
