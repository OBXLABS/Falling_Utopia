using UnityEngine;
using System.Collections;

/*This class determines if the falling person is dead or not*/
public class KillPerson : MonoBehaviour {

	//reference to the ghost rigidbody object
	public Rigidbody2D deadPerson;

	//determines if the death has happened or not
	bool dead = false;

	//at each frame...
	void Update () {

		////determines the object position relative to the camera
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);

		//if the object hits the bottom of the camera
		if ((screenPosition.x > (Screen.width/2 - Screen.width/8)) && (screenPosition.x < (Screen.width/2 + Screen.width/8) && screenPosition.y < Screen.height/7) || screenPosition.y < 0) {

			//records this death in the scene's people statistics
			DeathManager.peopleDead += 1;
			PeopleManager.peopleLeft -= 1;

			//if the death hasn't happened yet
			if(!dead) {

				//instatiate the ghost and flag that the death has happended
				Instantiate (deadPerson, this.transform.position, Quaternion.identity);
				dead = true;
			}

			//destroy the object
			Destroy (this.gameObject);
		}
	}
}

