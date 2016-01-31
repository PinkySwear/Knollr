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
					+ " in " + (globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime));
			Debug.Log (globalThing.GetComponent<GlobalControl> ().lastLevelScore);
			Debug.Log (globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (globalThing == null) {
			globalThing = GameObject.Find ("Global");
		} else {
			statShower.GetComponent<Text> ().text = 
				((globalThing.GetComponent<GlobalControl> ().lastLevelScore) + "%"
					+ " in " + (globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime));
			Debug.Log (globalThing.GetComponent<GlobalControl> ().lastLevelScore);
			Debug.Log (globalThing.GetComponent<GlobalControl> ().lastLevelTotalTime);
		}
	}
}
