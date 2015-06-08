using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the bullet and its behaviours such as firing itself and keeps track of how much ammo is left*/
public class BulletBehaviour : MonoBehaviour {

	//reference to the bullet gameObject
	public Rigidbody2D bullet;

	//reference to the canon gameObject
	public Rigidbody2D canon;

	//determines the force of the bullet
	public float bulletForce = 10f;

	public static int ammo = 5;
	int ammoStart = 5;

	//instances of the bullet that are shot from the canon
	Rigidbody2D bulletClone;

	//determines whether to create an instance or not (allows only one instance created per mouse press)
	bool createInstance = true;

	//determines whether the player can shoot or not
	bool canShoot = true;

	//will only run at start of script
	void Start() {

		//sets the public boolean to its default state
		ammo = ammoStart;
	}

	//at each frame...
	void Update () {

		//locates the mouse position and stores it
		Vector3 mousePos = Input.mousePosition;

		//locates the location around the pause button and stores it
		float widthLimit = LevelButtonManager.button_width + LevelButtonManager.button_width/2;
		float heightLimit = LevelButtonManager.button_height + LevelButtonManager.button_height;

		//if the mouse if over the pause button...
		if (mousePos.x < widthLimit && mousePos.y > Screen.height - heightLimit)

			//the player cannot shoot
			canShoot = false;

		//otherwise...
		else

			//the player can shoot
			canShoot = true;

		//as long as there are people left to save, the pause menu is not open, the player can shoot and the tutorials are not on...
		if (PeopleManager.peopleLeft != 0 && !PauseMenu.paused && canShoot && !TutorialScript.tutorialOn) {

			//fire the instance of the bullet
			fire ();
		}
	}

	//fire the instance of the bullet towards the mouse
	void fire() {

		//if the left mouse button is pressed and there is ammo left to shoot with
		if (Input.GetButtonDown ("Fire1") && ammo > 0) {

			//if an instance hasn't been created...
			if(createInstance) {

				//new offset position for bullet so it is behind the canon
				Vector3 newPosition = new Vector3(canon.transform.position.x, canon.transform.position.y, canon.transform.position.z + 1);

				//create the instance of the bullet at the center of the canon
				bulletClone = Instantiate(bullet, newPosition, bullet.transform.rotation) as Rigidbody2D;

				//do not allow instance creation until mouse is released
				createInstance = false;

				//subtract from the ammo left until reload is necessary
				ammo--;

				//refresh the ammo reel to represent the new amount of ammo left
				AmmoReelScript.destroyThis = true;
				AmmoReelScript.isDestroyed = false;
				AmmoSpawnManager.canCreateAmmo = true;
			}

			//move the bullet towards the mouse
			moveBullet ();	
		}

		//if the left mouse button is released...
		if(Input.GetButtonUp ("Fire1")){

			//allow instance creation
			createInstance = true;
		}
	}

	//moves the bullet instance towards the mouse
	void moveBullet() {

		//mouse position 3D vector
		Vector3 mousePos;
		
		//determines the object position relative to the camera
		Vector3 objectPos;
		
		//determines the relative position of the mouse from the bullet
		Vector3 bulletSpeed;
		
		//get the mouse position and set it's z value to the distance between the camera and the canon
		mousePos = Input.mousePosition;
		mousePos.z = -(bulletClone.transform.position.x - Camera.main.transform.position.x);
		
		//set the object position relative to the camera
		objectPos = Camera.main.WorldToScreenPoint (bulletClone.transform.localPosition);
		
		//determines the relative mouse position as the x and y distance from the canon
		bulletSpeed.x = mousePos.x - objectPos.x;
		bulletSpeed.y = mousePos.y - objectPos.y;
		bulletSpeed.z = 0;

		//normalize the bulletSpeed to get the direction
		bulletSpeed.Normalize();

		//set the bulletClone's velocity to the new bullet speed
		bulletClone.velocity = new Vector3 (bulletSpeed.x * bulletForce, bulletSpeed.y * bulletForce, 0);

	}
}






