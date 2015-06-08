using UnityEngine;
using System.Collections;

/*This class controls the village's behaviour on the map screen */
public class villageScript : MonoBehaviour {

	//reference to the animator that controls the map icons
	public Animator map;

	//flags whether this is the player's first visit to the level
	public static bool firstVisit = true;

	void Update (){
		villageOpening ();
	}

	// This function sets the animator boolean to true
	// so that it plays automatically when the map scene is selected
	public void villageOpening(){
		if (!cityScript.lvl1isOver) {
			if (firstVisit)
					map.SetBool ("playAnim0", true);

			
			if (!firstVisit) {
					map.SetBool ("VillageSetToPosition", true);

			}
		}
	}
	
}
