using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*This class controls the metro sprite's behaviour and determines which sprite is being displayed*/
public class metroSpriteScript : MonoBehaviour {

	//reference to the three different sprites for the metropoltian
	public Sprite selectedMetro;
	public Sprite unlockedMetro;
	public Button buttonMetro;

	// This method is called in the animation event of the metro button animation
	// it overrides the sprite of the metro button with the unlocked metro sprite
	public void openMetro(){
		buttonMetro.image.overrideSprite = unlockedMetro;
		
	}

	// This method is called in the animation event of the metro button animation
	// it overrides the sprite of the metro button with the selcted metro sprite
	public void selectMetro(){
		buttonMetro.image.overrideSprite = selectedMetro;
	}
}
