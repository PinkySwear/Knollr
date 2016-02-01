using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

	public class RealLevelManager : MonoBehaviour {

		bool fadeOut;

		public int targetLevel;

	public AudioSource audioPlayer;

	public GameObject globalThing;


		public AudioSource mainCameraAudio;

		void Start(){
		if (globalThing == null) {
			globalThing = GameObject.Find ("Global");
		}
	}

		public void LoadPrevious(){
			Debug.Log("Level load requested for " + name); 
			SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex - 1));
		}
			
		public void LoadNext () {
		if(globalThing.GetComponent<GlobalControl> ().lastLevelBuildIndex == 7 
				|| globalThing.GetComponent<GlobalControl> ().lastLevelBuildIndex == 13)
				SceneManager.LoadScene ("Menu");
			else
				SceneManager.LoadScene ((globalThing.GetComponent<GlobalControl> ().lastLevelBuildIndex + 1));
		}
		
	public void LoadFirstZen () {
		SceneManager.LoadScene (9);
	}

		public void Restart(){
			Debug.Log("Restart!"); 
			SceneManager.LoadScene (globalThing.GetComponent<GlobalControl> ().lastLevelBuildIndex);
		}

		public void Begin(){
			Debug.Log("begin");
			fadeOut = true;
			StartCoroutine(StartGame(1.2f));
		}

		void Update() {
			if (!fadeOut) return;
			audioPlayer.volume = Mathf.Lerp(
			audioPlayer.volume, 0f, Time.deltaTime*2f);
		}
			

		public IEnumerator StartGame(float delay) {
			yield return new WaitForSeconds(delay);
			SceneManager.LoadScene("level1");
		}
		
		public void QuitLevel()	{
			Debug.Log("Quit requested");
			Application.Quit();
		}
		
		public void LoadMenu(){
			SceneManager.LoadScene("Menu");
		}

	public void loadCredits() {
		SceneManager.LoadScene ("Credits");
	}
		
	}