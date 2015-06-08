using UnityEngine;
using System.Collections;

/*This class allows the background music constently play from scene to scene*/
public class AudioContinue : MonoBehaviour {

	//starts with an empty instance of this class to check for duplicates
	private static AudioContinue instance = null;

	//retreives the instance of this class
	public static AudioContinue Instance {
		get { 
			return instance; 
		}
	}

	//called on startup
	void Awake() {

		//this if statement checks to see if there is a duplicate of the instance and will destroy it if there is
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} 

		//if the instance is empty than fill it with this
		else {
			instance = this;
		}


		//do not destroy this game object when a scene is loaded. This allows the music to continue throughout the scenes
		DontDestroyOnLoad(this.gameObject);
	}
}
