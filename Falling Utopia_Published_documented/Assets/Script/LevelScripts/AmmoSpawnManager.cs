using UnityEngine;
using System.Collections;

/*This class controls the amount of parachute icons that spawn in the ammo reel*/
public class AmmoSpawnManager : MonoBehaviour {

	//gets the reference to the ammo game object (parachute Icon)
	public GameObject ammo;

	//determines if the ammo reel should be created or not
	public static bool canCreateAmmo = true;

	//the default boolean to set the above boolean to upon script start
	bool canCreateAmmoStart = true;

	//determines the offset distance between each parachute icon in the reel
	public float offset = 10f;

	//will only run at start of script
	void Start() {

		//sets the public boolean to its default state
		canCreateAmmo = canCreateAmmoStart;
	}
	
	// Update is called once per frame
	void Update () {

		//references the number of bullets left before reload
		int numberOfParachutes = BulletBehaviour.ammo;

		//if the ammo reel is destroyed
		if (AmmoReelScript.isDestroyed)

			//flag it so it doesn't get destroyed again
			AmmoReelScript.destroyThis = false;

		//for each parachute left
		for(int i = 0; i < numberOfParachutes; i++){

			//if it is time to create the ammo reel
			if(canCreateAmmo) {

				//sets a new position vector for each parachute icon and instatiates it at that position
				Vector3 newPosition = new Vector3(this.transform.position.x + i * offset, this.transform.position.y, this.transform.position.z);
				Instantiate(ammo, newPosition, this.transform.rotation);

			}
		}

		//since the ammor reel has just been created do not allow it to be recreated
		canCreateAmmo = false;
	}
}
