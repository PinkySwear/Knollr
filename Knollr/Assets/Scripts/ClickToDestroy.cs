using UnityEngine;
using System.Collections;

public class ClickToDestroy : MonoBehaviour {

	public bool wait2;

	public void DestroySelf(){
		Invoke ("MoveOn", .3f);
	}

	public void MoveOn(){
		Destroy (this.gameObject);
		wait2 = false;
	}


}
