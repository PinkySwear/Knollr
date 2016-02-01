using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour {


	public float lastLevelScore;
	public int lastLevelTotalTime;
	public int lastLevelTimeLeft;
	public int lastLevelBuildIndex;


	public static GlobalControl Instance;

	void Awake () {
		DontDestroyOnLoad (this.gameObject);
//		if (Instance == null) {
//			DontDestroyOnLoad (this.gameObject);
//			Instance = this;
//		} else if (Instance != this) {
//			Destroy (gameObject);
//		}
	}
}
