using UnityEngine;
using System.Collections;

/*This class allows the player to go forward to the map screen*/
public class goToMapScript : MonoBehaviour {

	//send the player to the map screen
	public void goToMap(){
		Application.LoadLevel (1);
	}
}
