using UnityEngine;
using System.Collections;

/*This class controls the rotation of the canon in regards to where the player is pointing*/
public class CanonBehaviour : MonoBehaviour {

	//at each frame...
	void Update () {

		//as long as there are people left to save and the pause menu is not open...
		if (PeopleManager.peopleLeft != 0 && !PauseMenu.paused && !TutorialScript.tutorialOn)

			//roate the canon relative to the mouse position
			rotate ();
	}

	//rotates the canon relative to the mouse position
	void rotate() {

		//canon's angle of rotation
		float rotAngle;

		//fixed canon rotation angle
		float rotAngle_Fixed;

		//mouse position 3D vector
		Vector3 mousePos;

		//determines the object position relative to the camera
		Vector3 objectPos;

		//determines the relative position of the mouse from the canon
		Vector3 mousePosRelative;

		//get the mouse position and set it's z value to the distance between the camera and the canon
		mousePos = Input.mousePosition;
		mousePos.z = -(transform.position.x - Camera.main.transform.position.x);

		//set the object position relative to the camera
		objectPos = Camera.main.WorldToScreenPoint (transform.localPosition);

		//determines the relative mouse position as the x and y distance from the canon
		mousePosRelative.x = mousePos.x - objectPos.x;
		mousePosRelative.y = mousePos.y - objectPos.y;

		//uses inverse tan function to calculate the angle between the canon and the mouse (converted to degrees)
		rotAngle = Mathf.Atan2 (mousePosRelative.y, mousePosRelative.x) * Mathf.Rad2Deg;

		//fixes the rotation angle to match the original canon angle
		rotAngle_Fixed = rotAngle + 90 + 180;

		//rotate the canon
		transform.rotation = Quaternion.Euler(0,0,rotAngle_Fixed);
	}
}
