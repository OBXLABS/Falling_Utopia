using UnityEngine;
using System.Collections;

/*This class controls the city's bechaviour on the map screen*/
public class cityScript : MonoBehaviour {

	//reference to the animator that controls the map's animations
	public Animator map;

	//flag whether the first level is beaten or not
	public static bool lvl1isOver = false;

	//flag whether the village is unlocked
	public static bool villageOpen = false;

	//flag whether it is the player's first time 
	public static bool firstVisit = true;

	//at each frame
	void Update (){
		fromVillageToCity ();
	}

	//perform the animation that cycles from village to city
	public void fromVillageToCity(){

		//when the level 1 ends it sets this boolean to true
		//it should be set when the button is pressed to go to the map screen
		if (lvl1isOver && !metroScript.lvl2isOver) {

			//if it's the player's first visit player the cycle animation
			if (firstVisit) {
				// sets the city animator booleans to true
				// and the transition from the village to the city animation boolean to true
				// sets the animation of the village to false so that it won't play again
				//sets the static boolean village open, that is used to override the locked state in the village script
				map.SetBool ("playAnim1", true);
				map.SetBool ("playAnim0Out", true);
				map.SetBool ("playAnim0", false);
				villageOpen = true;
			}

			//otherwise play the iddle animation (city in active position)
			if (!firstVisit)
				map.SetBool ("CitySetToPosition", true);
		}
	}


}
