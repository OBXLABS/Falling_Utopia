using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class keeps track of the number of people rescued */
public class RescueManager : MonoBehaviour {

	//determines the number of people that has been rescued
	public static int peopleRescued;

	//determines the number of people that needs to be rescued for the level to be beaten
	public static int rescuedCondition;

	//sets the initial amount of rescued people
	int initialRescuedPeople = 0;

	//sets the rescue condition
	public int setRescuedCondition;

	//reference to text that displays the number of people saved
	Text resultsSaved;

	//upon startup of script
	void Awake ()
	{
		//fetch the text from the game object
		resultsSaved = GetComponent <Text> ();

		//set the default values
		peopleRescued = initialRescuedPeople;
		rescuedCondition = setRescuedCondition;
	}

	//at each frame
	void Update() {

		//edit the value of the text to the number of people that has been saved
		resultsSaved.text = "Citizens saved: \n" + peopleRescued;
	}
}
