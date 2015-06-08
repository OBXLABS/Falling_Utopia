using UnityEngine;
using System.Collections;

public class BabyMovement : MonoBehaviour {

	//determines the speed and extent of motion of the baby
	public float xSpeed;
	public float xSpeedScale;

	//references to the baby rigid body object
	public Rigidbody2D baby;

	//original x speed of the baby
	float xVelocity = 0;

	//determines the speed of falling
	public float fallingSpeed = 0;

	//determines the speed of rotation
	public float rotateSpeed = 100f;
	
	//flags if the baby is rotating right
	bool rotateRight = true;

	//keeps track of framecount used in rotation
	int counter = 0;

	//at each frame...
	void Update () {
		
		//makes the baby fall down in a wavy motion
		fallDown ();

		//as long as the pause menu is not open...
		if(!PauseMenu.paused)

			//rotates the person left to right
			rotate ();
		
	}
	
	//makes the person fall strait down by fallingSpeed
	void fallDown() {

		//as long as the pause menu is not open...
		if (!PauseMenu.paused) {

			//set the baby velocity to a horisontal sin function and a vertical straight line
			baby.velocity = new Vector3 (Mathf.Sin (xVelocity) * xSpeedScale, -fallingSpeed, 0);

			//increments the sin function parameter so it moves in a wave motion
			xVelocity = xVelocity + xSpeed;
		}

		//otherwise the pause menu is open...
		else

			//set the baby velociy to 0
			baby.velocity = new Vector3 (0, 0, 0);
		
	}

	//rotates the person left to right
	void rotate() {
		
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
			baby.transform.Rotate (0, 0, rotateSpeed * Time.deltaTime);
		} 
		
		//otherwise the person is rotating left...
		else {
			
			//rotate it to the left by rotateSpeed
			baby.transform.Rotate (0, 0, -rotateSpeed * Time.deltaTime);
		}
		
		//when the counter reaches 60 make it 0 to prevent overflow
		if (counter > 60) {
			counter = 0;
		}
	} 

}











