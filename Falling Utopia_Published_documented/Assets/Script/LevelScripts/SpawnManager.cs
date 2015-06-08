using UnityEngine;
using System.Collections;

/*This class controls the spawning of the falling people*/
public class SpawnManager : MonoBehaviour {

	//reference to the person gameObject
	public GameObject[] people;

	//determines the amount of time between spawns
	public float spawnTime = 3f;

	//determines when the first person is spawned
	public float startTime = 0f;

	//reference to the spawnpoint gameObject
	public Transform spawnPoint;

	//at start of script call...
	void Start (){

		//set up a repeating cycle for the spawning
		InvokeRepeating ("Spawn", startTime, spawnTime);
	}
	
	//spawns instances of the person
	void Spawn ()
	{
		//if there are no more people on the island or the game is paused or the tutorial is on
		if (PeopleManager.peopleOnIsland == 0 || PauseMenu.paused || TutorialScript.tutorialOn){

			//escape from the function and do nothing
			return;
		}

		//randomise the index so it spawns people at random
		int peopleIndex = Random.Range (0, people.Length);

		//create an instance of the person at the spawnPoint
		Instantiate (people[peopleIndex], spawnPoint.position, spawnPoint.rotation);

		//subtract from the people left on island at each spawn
		PeopleManager.peopleOnIsland -= 1;
	}
}
