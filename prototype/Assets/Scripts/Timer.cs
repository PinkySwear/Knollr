using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke( "ChangeLevel", 4.8f );
 }
 
 void ChangeLevel() {
		SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex + 1));  
 }

}

