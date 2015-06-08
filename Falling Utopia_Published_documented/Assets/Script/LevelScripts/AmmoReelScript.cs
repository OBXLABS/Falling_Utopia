using UnityEngine;
using System.Collections;

/*this class controls the ammo reel objects to be visible only when the appropriate number of parachutes are left 
i.e. 3 parachutes will be displayed if you can only shoot 3 parachutes before you have to reload*/
public class AmmoReelScript : MonoBehaviour {

	//a boolean visible to all classes, determines if it is time to destroy the ammo reel in order to refresh it
	public static bool destroyThis = false;

	//a boolean visible to all classes, determines if the ammo reel has been destroyed in ordser for proper timing of the refresh
	public static bool isDestroyed = false;

	//the 2 default booleans to set the above booleans to upon script start
	bool destroyThisStart = false;
	bool isDestroyedStart = false;

	//will only run at start of script
	void Start(){

		//sets both public booleans to their default states
		destroyThis = destroyThisStart;
		isDestroyed = isDestroyedStart;
	}

	// Update is called once per frame
	void Update () {

		//if it is time to destroy the ammo reel
		if (destroyThis) {

			//destroy the game object and flag it as being destroyed
			Destroy (this.gameObject);
			isDestroyed = true;
		}
	}
}
