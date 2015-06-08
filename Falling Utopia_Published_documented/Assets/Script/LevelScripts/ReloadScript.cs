using UnityEngine;
using System.Collections;

/*This class controls the reload button*/
public class ReloadScript : MonoBehaviour {

	//reference to the reload animator
	public Animator reload;

	//at each frame...
	void Update () {

		//if the player is out of ammo
		if (BulletBehaviour.ammo == 0)

			//play the reload animation
			reload.SetBool ("Reload", true);
	}

	//function that controls the reload of the canon
	public void reloadCanon() {

		//sets the ammo back to 5 and re-creates the ammo reel
		BulletBehaviour.ammo = 5;
		AmmoSpawnManager.canCreateAmmo = true;

		//stops the reload animation
		reload.SetBool ("Reload", false);
	}
}
