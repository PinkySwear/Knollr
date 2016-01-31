using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loseManager : MonoBehaviour {

	public GameObject statShower;
	public GameObject globalThing;

	// Use this for initialization
	void Start () {
		if (globalThing == null) {
			globalThing = GameObject.Find ("Global");
		} else {
			statShower.GetComponent<Text> ().text = 
				((globalThing.GetComponent<GlobalControl> ().lastLevelScore) + "%"
					+ " in " + (convertTime( (globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime))));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (globalThing == null) {
			globalThing = GameObject.Find ("Global");
		} else {
			statShower.GetComponent<Text> ().text = 
				((globalThing.GetComponent<GlobalControl> ().lastLevelScore) + "%"
					+ " in " + (convertTime( (globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime))));
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
