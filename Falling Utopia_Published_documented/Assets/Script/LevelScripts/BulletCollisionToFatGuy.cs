using UnityEngine;
using System.Collections;

/*This class controls the behaviour of the fat guy and keeps track of the number of parachutes he has*/
public class BulletCollisionToFatGuy : MonoBehaviour {

	//reference to the fat guy prefab with one parachute
	public Rigidbody2D oneParachute;

	//determines if the object has been changed yet or not
	bool change = false;

	//destroys both the bullet and the person when the person is hit by a bullet and adds 1 to the peopleRescued
	void OnCollisionEnter2D(Collision2D other) {

		//if the object is hit by an object with the "bullet" tag... 
		if (other.gameObject.tag == "bullet") {

			//changes the fat guy to the fat guy with one parachute
			if (!change) {
					Instantiate (oneParachute, this.transform.position, Quaternion.identity);
					change = true;
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
