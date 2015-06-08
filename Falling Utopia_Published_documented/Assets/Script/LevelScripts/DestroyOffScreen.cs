using UnityEngine;
using System.Collections;

/*This class will kill the bullet when it leaves the screen area*/
public class DestroyOffScreen : MonoBehaviour {

	//at each frame...
	void Update () {

		//determines the object position relative to the camera
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);

		//if the object is no longer in the camera's view (on screen)...
		if (screenPosition.y > Screen.height || screenPosition.y < 0f || screenPosition.x > Screen.width || screenPosition.x < 0f) {

			//destroy the object
			Destroy (this.gameObject);
		}
	}
}
