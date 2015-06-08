using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the falling action of the falling people*/
public class Fall : MonoBehaviour {

	//reference to the person gameObject
	public Rigidbody2D person;

	//determines the speed of falling
	public float fallingSpeed = 0;

	//determines the speed of rotation
	public float rotateSpeed = 100f;

	//flags if the person is rotating right
	bool rotateRight = true;

	//keeps track of framecount
	int counter = 0;
	
	//at each frame...
	void Update () {

		//makes the person fall straight down
		fallDown ();

		if (!PauseMenu.paused) 
		//rotates the person left to right
		rotate ();

	}

	//makes the person fall strait down by fallingSpeed
	void fallDown() {
		Vector3 acceleration = Input.acceleration;
		if (!PauseMenu.paused) {
			person.velocity = new Vector3 (acceleration.x * fallingSpeed * 2, -fallingSpeed, 0.0f);
		} else {
			person.velocity = new Vector3 (0, 0, 0);
		}
		
	}

	//rotates the person left to right
	void rotate() {
		Vector3 acceleration = Input.acceleration;

		//increase the counter at each frame to keep track of time
		counter ++;

		//if the counter is devisable by 60...
		if (counter % 60 == 0) {

			//alternate the rotateRight state
			rotateRight =! rotateRight;
		}

		//if the person is rotating right...
		if (rotateRight) {

			//rotate it to the right by rotateSoeed
			person.transform.Rotate (0, 0, rotateSpeed * Time.deltaTime);

		} 

		//otherwise the person is rotating left...
		else {

			//rotate it to the left by rotateSpeed
			person.transform.Rotate (0, 0, -rotateSpeed * Time.deltaTime);
		}

		//when the counter reaches 60 make it 0 to prevent overflow
		if (counter > 60) {
			counter = 0;
		}
	} 


	

}
