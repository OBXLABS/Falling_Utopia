using UnityEngine;
using System.Collections;

/*This class controls the end screen animations depending on if the player has passed or failed the level*/
public class AnimatorControllerLV1 : MonoBehaviour {

	//reference to the animator object that controls the ending animations
	public Animator endScreen;

	// Update is called once per frame
	void Update () {

		//if the number of people left is equal to 0...
		if (PeopleManager.peopleLeft == 0) {
			//if the number of people rescued is greater than or equal to the number of people needed to be saved to pass...
			if (RescueManager.peopleRescued >= RescueManager.rescuedCondition){
				//run the win animation
				endScreen.SetBool ("hasWon", true);
			}
			//otherwise...
			else{
				//run the try again animation
				endScreen.SetBool ("hasLost", true);
			}
		} 
	}
}
