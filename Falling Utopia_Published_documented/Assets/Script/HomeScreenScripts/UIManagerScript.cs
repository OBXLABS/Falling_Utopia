using UnityEngine;
using System.Collections;

/*This class controls the UI on the home screen*/
public class UIManagerScript : MonoBehaviour {

	//reference to the animator that controls the falling man animation
	public Animator startFallingMan;

	//reference to the animator that controls the start button dissapearing
	public Animator btnDisappear;

	//reference to the animatpr that controls the flickering of the button
	public Animator stopFlickering;

	//reference to the animator that controls the animation of the credit page
	public Animator credits;

	//reference to the falling man object
	public Rigidbody2D fallingMan;

	//starts the animation of the falling man which ends by sending the player to the map page
	public void triggerFallingMan(){
		startFallingMan.SetBool ("isFalling", true);
	}

	//stops all start button animation and hides it
	public void disappearButton(){
		btnDisappear.SetBool ("isHidden", true);
		stopFlickering.SetBool ("isFlickering", false);
	}

	//brings the credit page into view
	public void showCredits(){
		credits.SetBool ("isCreditShown", true);
		credits.SetBool ("isCreditHidden", false);
	}

	//removes the credit page from view
	public void hideCredits(){
		credits.SetBool ("isCreditShown", false);
		credits.SetBool ("isCreditHidden", true);
	}




}