
using UnityEngine;
using System.Collections;

//This class controls the Metro behaviour on the Map scene
public class metroScript : MonoBehaviour {

	//Reference to the animator that controls the map's animations
	public Animator map;

	//Flags whether the second level is over 
	public static bool lvl2isOver = false;

	//Flags whether the City has been unlocked 
	public static bool cityOpen = false;

	//Flags whether the Metro has been unlocked
	public static bool metroOpen = false;


	public static bool firstVisit = true;

	//The looping environment
	void Update (){

		//Calling the function 
		fromCityToMetro ();

	}

	//This function checks if levels 1 and 2 are over
	//and accordingly it plays the animation of the map
	//that rotates and places the Metro map at the center
	public void fromCityToMetro(){

		//if the condition is true then play the animation
		if (lvl2isOver && cityScript.lvl1isOver) {

			//This condition is setup for the tutorialand for pausing the Map rotation where it has been reached
			//it checks whether the third level has been accessed for the first time
			//if true then the tutorial is displayed
			if (firstVisit) {

				//Sets the second animation from city to metro to true
				map.SetBool ("playAnim2", true);

				//Sets the Exit of the first animation and the first animation (Village) to false
				map.SetBool ("playAnim0Out", false);
				map.SetBool ("playAnim0", false);

				//Sets the Exit of the second animation and the second animation (City) to false
				map.SetBool ("playAnim1Out", true);
				map.SetBool ("playAnim1", false);

				//Sets the static booleans for the City and Metro to true
				cityOpen = true;
				metroOpen = true;
			}

			//If this is not the first visit
			//then set the fixed position of the map that shows the Metro map at the center to true
			if (!firstVisit)
				map.SetBool ("MetroSetToPosition", true);
		}
	}
	
	

}
