using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*This class controls the city sprite's behaviour and determines which sprite is being displayed*/
public class citySpriteScript : MonoBehaviour {

	//reference to the three different sprites for the city
	public Sprite selectedCity;
	public Sprite unlockedCity;
	public Button buttonCity;

	void Update(){
	
		// if the boolean in the metro script was set to true
		// then override the locked Sprite with the unlocked one
		if (metroScript.cityOpen) {
			openCity();
		}
	}

	// This method overrides the city button sprite with the unlocked city sprite 
	public void openCity(){
		buttonCity.image.overrideSprite = unlockedCity;
	}

	// This method is called in the animation event of the city button animation
	// it overrides the sprite of the city button with the selcted city sprite
	public void selectCity(){
		buttonCity.image.overrideSprite = selectedCity;
	}
}
