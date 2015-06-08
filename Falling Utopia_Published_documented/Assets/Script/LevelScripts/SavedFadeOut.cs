using UnityEngine;
using System.Collections;

/*This class controls the fading of the saved people*/
public class SavedFadeOut : MonoBehaviour {

	//references the ghost rigidbody object to be used
	public Rigidbody2D SavedPerson;
	
	//determines the speed of fading
	public byte fadeSpeed = 10;
	
	//sets the color reference for the ghost
	Color32 FadeColor;
	
	void Start() {
		FadeColor = SavedPerson.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		fadeOut ();
	}
	
	void fadeOut() {

		//if the transperancy of the person is greater than 5
		if (FadeColor.a > 5) {

			//reduce the transperancy by faadeSpeed
			SavedPerson.GetComponent<SpriteRenderer>().color = FadeColor;
			FadeColor.a -= fadeSpeed;
		}

		//otherwise destroy the object
		else {
			Destroy (this.gameObject);
		}
	}
}