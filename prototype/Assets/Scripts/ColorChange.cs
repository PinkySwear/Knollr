using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	// Change these to the appropriate colors for the individual pieces
	public Color colorStart = Color.black;
	public Color colorEnd = Color.white;

	// Tune for the game experience on placement of pieces next to each other
	public float duration = 1.0f;
	public float pause = 1.0f;

	// Necessary for looping behavior of the color pulse
	private Renderer rend;
	private bool start = false;
	private bool passedPoint = false;


	void Start() {
		rend = GetComponent<Renderer>();
	}


	void Update (){
		if (Input.GetKeyUp (KeyCode.UpArrow) && !start) {
			start = true;
		}
		if (start) StartCoroutine (LerpColor ());
	}


	IEnumerator LerpColor() {

		float lerp = Mathf.PingPong (Time.time, duration) / duration;

		rend.material.color = Color.Lerp (colorStart, colorEnd, lerp);

		if (rend.material.color.r > (colorEnd.r - 0.1f))
			passedPoint = true;
		
		if ((Mathf.Abs (rend.material.color.r - colorStart.r) < 0.1f) && passedPoint) {
			start = false;
			passedPoint = false;
		}
			yield return new WaitForSeconds (pause);
	}
}