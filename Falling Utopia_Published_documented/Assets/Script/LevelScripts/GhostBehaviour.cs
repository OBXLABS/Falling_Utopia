using UnityEngine;
using System.Collections;

/*This class controls the behaviour of the ghost once a person dies*/
public class GhostBehaviour : MonoBehaviour {

	//references the ghost rigidbody object to be used
	public Rigidbody2D ghost;

	//determines the speed of rise and rotation
	public float riseSpeed = 5f;

	//determines the speed of fading
	public byte fadeSpeed = 10;

	//sets the color reference for the ghost
	Color32 ghostColor;

	//will only run once the script is created
	void Awake() {
		ghostColor = ghost.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update () {
		rise ();
		fadeOut ();
	}

	//makes the ghost rise
	void rise() {
		ghost.velocity = new Vector3 (0, riseSpeed, 0);
	}

	//fades the ghost out
	void fadeOut() {

		//if the transperancy value of the ghost is greater than 5
		if (ghostColor.a > 5) {

			//reduce its transperancy by fadeSpeed
			ghost.GetComponent<SpriteRenderer>().color = ghostColor;
			ghostColor.a -= fadeSpeed;
		}

		//otherwise destroy it
		else {
			Destroy (this.gameObject);
		}
	}
}
