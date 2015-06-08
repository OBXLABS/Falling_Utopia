using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*This class controls the village sprite's behaviour and determines which sprite is being displayed*/
public class villageSpriteScript : MonoBehaviour {

	//reference to the three sprites for the village
	public Sprite selectedVillage;
	public Sprite unlockedVillage;
	public Button buttonVillage;

	void Update(){
		// checks if the boolean was set to true in the cityScript file
		// and calls the function that overrides 
		// the locked village sprite with the unlocked sprite
		if (cityScript.villageOpen) {
			openVillage ();
		}
	}

	// this function overrides the sprite of the village button with the unlocked sprite 
	public void openVillage(){
		buttonVillage.image.overrideSprite = unlockedVillage;
	}

	// This method is called in the animation event of the village button animation
	// it overrides the sprite of the village button with the selcted village sprite
	public void selectVillage(){
		buttonVillage.image.overrideSprite = selectedVillage;
	}
	
}
