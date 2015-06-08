using UnityEngine;
using System.Collections;

/*This class controls the interaction between the falling people and the bullet*/
public class BulletCollisionToPerson : MonoBehaviour {

	//reference to the saved person object
	public Rigidbody2D savedPerson;

	//determines whether the person has been saved yet or not
	bool saved = false;

	//destroys both the bullet and the person when the person is hit by a bullet and adds 1 to the peopleRescued
	void OnCollisionEnter2D(Collision2D other) {

		//if the object hits an object with the "bullet" tag...
		if (other.gameObject.tag == "bullet") {

			//add one to the number of people rescued
			RescueManager.peopleRescued += 1;
			PeopleManager.peopleLeft -= 1;

			//changes the falling person to the saved person only once
			if (!saved) {
					Instantiate (savedPerson, this.transform.position, Quaternion.identity);
					saved = true;
			}

			//destroy both objects
			Destroy (this.gameObject);
			Destroy (other.gameObject);

		} 
	}

	//ignores collision with the baby layer (this prevents bumper car reactions between falling people and the baby)
	void Update() {
		Physics2D.IgnoreLayerCollision (9, 0);
	}
}
