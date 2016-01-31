using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winManager : MonoBehaviour {

	public GameObject statShower;
	public GameObject statShower2;
	public GameObject globalThing;

	// Use this for initialization
	void Start () {
		if (globalThing == null) {
			globalThing = GameObject.Find ("Global");
		} else {
			statShower.GetComponent<Text> ().text = 
				((globalThing.GetComponent<GlobalControl> ().lastLevelScore) + "%"
					+ " in " + convertTime(((globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime) - (globalThing.GetComponent<GlobalControl> ().lastLevelTimeLeft))));
			statShower2.GetComponent<Text> ().text = 
					"+" + (convertTime( (globalThing.GetComponent<GlobalControl> ().lastLevelTimeLeft))) + " for next round";
		}
	}

	// Update is called once per frame
	void Update () {
		if (globalThing == null) {
			globalThing = GameObject.Find ("Global");
		} else {
			statShower.GetComponent<Text> ().text = 
				((globalThing.GetComponent<GlobalControl> ().lastLevelScore) + "%"
					+ " in " + convertTime(((globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime) - (globalThing.GetComponent<GlobalControl> ().lastLevelTimeLeft))));
					statShower2.GetComponent<Text> ().text = 
					"+" + (convertTime( (globalThing.GetComponent<GlobalControl> ().lastLevelTimeLeft))) + " for next round";
		}
	}

	private string convertTime(int rawTime) {
		string timeVal;
		if (rawTime % 60 > 9){
			timeVal = (rawTime / 60) + ":" + (rawTime % 60);
		}
		else { 
			timeVal = (rawTime / 60) + ":0" + (rawTime % 60);
		}
		return timeVal;
	}
}
