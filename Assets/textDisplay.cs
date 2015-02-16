using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textDisplay : MonoBehaviour {

	GameObject UFO;
	GameObject treasure;
	bool haveYouWon = false;

	// Use this for initialization
	void Start () {
		UFO = GameObject.Find("UFO");
		treasure = GameObject.Find ("treasureChest");
	}
	
	// Update is called once per frame
	void Update (){
		float dist = Vector3.Distance(treasure.transform.position,(UFO.transform.position));
		string textBuffer = "Your distance from the treasure is:" + dist.ToString();
		if (!haveYouWon) {
			if (dist < 260) {
				textBuffer += "\nCongratulations! The treasure is directly below you. \nPress [SPACE] to obtain treasure.";
				if (Input.GetKeyDown(KeyCode.Space)) {
					haveYouWon = true;
				}
			} else if (dist < 700) {
				textBuffer += "\nThe treasure is around you somewhere.";
			} else if (dist < 1000) {
				textBuffer += "\nKeep looking.";
			} else {
				textBuffer += "\nYou're quite far away from the treasure.";
			}

		} else {
			textBuffer += "\nYou have won."; 
		}
		GetComponent<Text>().text = textBuffer;
	}
}
