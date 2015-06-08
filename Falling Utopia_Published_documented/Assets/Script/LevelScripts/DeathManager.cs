using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class keeps track of the number of people that have died in the scene*/
public class DeathManager : MonoBehaviour {

	//sets number of people that have died
	public static int peopleDead;
	int initialDeadPeople = 0;

	//reference to the text for the amount of people killed
	Text resultsDied;

	//performs on script startup
	void Awake ()
	{
		//fetch the text from the object's list of components
		resultsDied = GetComponent <Text> ();

		//sets the number of dead people to 0
		peopleDead = initialDeadPeople;
	}

	//at each frame...
	void Update() {

		//edit the value of the text to the number of people that has died
		resultsDied.text = "Citizens died: \n" + peopleDead;
	}
}
