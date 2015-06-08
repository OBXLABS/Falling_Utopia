using UnityEngine;
using System.Collections;

/*This class controls the movement of the island and everything on it*/
public class MoveIsland : MonoBehaviour {

	//specifiy the onject that will be moved
	public Rigidbody2D mover;

	//determines the speed of the movement
	public float speed;

	//reference for the edges of the island
	public Rigidbody2D rightEdge;
	public Rigidbody2D leftEdge;

	//determines the amplitude of movement
	public float amplitude;

	//counts where the Cos function is at and set a mod to control the max number it can reach (to prevent crash)
	float counter;
	float mod;

	//sets the original x position of the island
	float originalX;

	//performs on script startup
	void Awake() {

		//set the counter to zero and the mod to 1000000
		float counter = 0;
		float mod = 1000000;

		//determines the object position relative to the camera
		Vector2 rightPosition = Camera.main.WorldToScreenPoint (rightEdge.position);
		Vector2 leftPosition = Camera.main.WorldToScreenPoint (leftEdge.position);
		amplitude = 1+ 1/(rightPosition.x - Screen.width);

	}
	
	// Update is called once per frame
	void Update () {

		//as long as there are people left to save, the pause menu is not on and the tutorial is not on
		if (PeopleManager.peopleLeft != 0 && !PauseMenu.paused && !TutorialScript.tutorialOn) {

			//add the counter at each second
			counter += Time.deltaTime;

			//determines the x using a Cos funciton (limited by the amplitude and speed
			float x = amplitude * Mathf.Cos (speed*counter);

			//set the mover's velocity to the new x
			mover.velocity = new Vector3 (x, 0, 0);
		}

		//if there are no more people left, the menu is on or the tutorial is on
		if (PeopleManager.peopleLeft == 0 || PauseMenu.paused || TutorialScript.tutorialOn) {

			//stop the movement and counter
			mover.velocity = new Vector3 (0, 0, 0);
			counter += 0;
		}

	}

}
