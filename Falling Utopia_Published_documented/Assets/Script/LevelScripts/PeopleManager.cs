using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*This class controls the number of people left on the island*/ 
public class PeopleManager : MonoBehaviour {

	//determines the number of peolpe left on the island
	static public int peopleOnIsland;

	//reference to the slider that shows how many people are left to save
	public Slider citizenSlider;

	//determines the number of people left to save (including people already falling)
	static public int peopleLeft;

	//default number of people to set on script startup
	public int initialPeople;

	//the first time the script is called
	void Awake() {

		//set public ints to the default value
		peopleOnIsland = initialPeople;
		peopleLeft = peopleOnIsland;
	}

	// Update is called once per frame
	void Update () {

		//sets the max value of the slider to the initial amount of people
		citizenSlider.maxValue = initialPeople;

		//sets the slider's current value to the poeple left to save
		citizenSlider.value = peopleLeft;
	}
}
