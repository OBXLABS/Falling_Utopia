using UnityEngine;
using System.Collections;

/*This class controls the win and lose sounds*/
public class PlaySound : MonoBehaviour {

	//gets the array of sounds in the object and plays the first sound (victory)
	public void PlayWin(){
		AudioSource[] sounds = GetComponents<AudioSource> ();
		sounds [0].Play ();
	}

	//gets the array fo sounds in the object and plays the second sound (loss)
	public void PlayLose(){
		AudioSource[] sounds = GetComponents<AudioSource> ();
		sounds [1].Play ();
	}

}
