using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour {

	private Vector3 screenPoint;

	private float xDeg;
	private float yDeg;
	private Rigidbody rb;
	private bool dragging;
	private bool rotating;
	private bool over;
	public bool valid;
	public BoxCollider colorCollider;
	public Quaternion lockedRotation;
	public bool isTriangle;
	public float area;
	public bool triggered;
	public AudioClip placed;
	public AudioClip powerup;

    public bool hasExtra;
	public Board board;
	public Bounds myBounds;
	public int sides;
	public Color myColor;
	public float size;
	private Vector3 offset;
	private Vector3 lockedUp;


	// Use this for initialization
	void Start () {
		if (isTriangle) {
			area = (1f / 2f) * transform.localScale.x * transform.localScale.y;
		} else {
			area = transform.localScale.x * transform.localScale.y;
		}

		rb = GetComponent<Rigidbody> ();
		size = transform.lossyScale.x;
		GetComponent<BoxCollider>().size = new Vector3 ((9f - (4f - transform.localScale.x) * 2f)/transform.localScale.x,
			(9f - (4f - transform.localScale.y) * 2f)/transform.localScale.y, 2f);
		GetComponent<BoxCollider> ().isTrigger = true;
		triggered = false;
		lockedRotation = transform.rotation;
//		Debug.Log (transform.rotation.eulerAngles.z);
		xDeg = transform.rotation.eulerAngles.y;
		myColor = this.gameObject.GetComponent<Renderer> ().material.color;
		valid = false;

	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Renderer> ().material.color = myColor;
//		if (valid) {
//			this.gameObject.GetComponent<Renderer> ().material.color = myColor;
//		} else {
//			this.gameObject.GetComponent<Renderer> ().material.color = new Color(myColor.r + 0.2f, myColor.g, myColor.b);
//		}
//
//		if (valid) {
//			this.gameObject.GetComponent<Renderer> ().material.color = Color.white;
//		} else {
//			this.gameObject.GetComponent<Renderer> ().material.color = myColor;
//		}

//		Debug.DrawRay (transform.position, transform.forward * 100f, Color.red);

//		if ((board.aboveBounds.Contains (GetComponent<MeshRenderer> ().bounds.max) ||
//			board.aboveBounds.Contains (GetComponent<MeshRenderer> ().bounds.min)) &&
//			Vector3.Angle(transform.forward, Vector3.up) < 0.1f &&
//			transform.position.y < -0.6f) {

		if (board.aboveBounds.Contains (transform.position) &&
			Vector3.Angle(transform.forward, Vector3.up) < 1f &&
			transform.position.y < -0.6f) {
			valid = true;
		} else {
			valid = false;
		}



		if (transform.rotation.eulerAngles.z == 0f) {
			lockedRotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
		}

		if (!dragging) {
			lockedRotation = transform.rotation;
			lockedUp = transform.up;
		}
			
//		if (dragging) {
//			transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
//
//			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//			Vector3 curPos = Camera.main.ScreenToWorldPoint (curScreenPoint);
//			curPos.y = -0.5f;
//			transform.position = curPos;
////			transform.rotation = Quaternion.Lerp(transform.rotation,lockedRotation,Time.deltaTime * 5);
////			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
////			transform.rotation = lockedRotation;
//			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0f, 0f, 0f);
//			valid = false;
//		}

		if (dragging) {
			this.gameObject.GetComponent<Renderer> ().material.color = new Color(myColor.r + 0.1f, myColor.g + 0.1f, myColor.b + 0.1f);
			transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);

			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPos = Camera.main.ScreenToWorldPoint (curScreenPoint);
//			curPos.y = -0.5f;
			Vector3 temp = curPos + offset;
			transform.position = new Vector3 (temp.x, -0.5f, temp.z);
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0f, 0f, 0f);
//			transform.rotation = lockedRotation;
			transform.LookAt(transform.position+Vector3.up, lockedUp);
			valid = false;
		}

		if ((Input.GetMouseButtonDown (1) && over) || (Input.GetMouseButton(1) && rotating)) {
				rotating = true;
		}
		else {
			rotating = false;
		}

		if (rotating && !dragging) {
			this.gameObject.GetComponent<Renderer> ().material.color = new Color(myColor.r + 0.1f, myColor.g + 0.1f, myColor.b + 0.1f);
//			Debug.Log (xDeg);
			xDeg += Input.GetAxis("Mouse X") * 5;
//			xDeg += Mathf.Sqrt (Input.GetAxis ("Mouse X") * 3 * Input.GetAxis ("Mouse X") * 3 +
//				Input.GetAxis ("Mouse Y") * 3 * Input.GetAxis ("Mouse Y") * 3) * Mathf.Sign(Input.GetAxis("Mouse X"));

			//xDeg += Input.GetAxis("Mouse Y") * 3;
			Quaternion fromRotation = transform.rotation;
			Quaternion toRotation = Quaternion.Euler(270,xDeg, 0);
			transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime * 5);
			valid = false;

		}
//		Debug.Log (valid);

//		Color currentColor = this.gameObject.GetComponent<Renderer> ().material.color;
//		Color fromColor = this.gameObject.GetComponent<Renderer> ().material.color;
//		this.gameObject.GetComponent<Renderer> ().material.color = Color.Lerp (this.gameObject.GetComponent<Renderer> ().material.color, myColor, Time.deltaTime*5);
	}

	void flashColor() {
//		Debug.Log ("flash");
//		this.gameObject.GetComponent<Renderer> ().material.color = Color.white;
//		AudioSource.PlayClipAtPoint(powerup, transform.position);
	}


	void OnMouseDown() {
		dragging = true;
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPos = Camera.main.ScreenToWorldPoint (curScreenPoint);
		offset = transform.position - curPos;
//		Debug.Log("(" + offset.x + ", " + offset.y + ", " + offset.z + ")");
    }

	void OnMouseUp() {
		dragging = false;
		AudioSource.PlayClipAtPoint(placed, transform.position, 10f);
	}

	void OnMouseEnter() {
		over = true;
	}
		
	void OnMouseExit () {
		over = false;
	}

	void OnTriggerStay (Collider other) {
//		Debug.Log ("here at least");
//		Debug.Log (other.gameObject.tag == this.gameObject.tag + ", " + !triggered + ", " + valid + ", " + other.gameObject.GetComponent<Shape> ().valid);
//		Debug.Log ("tag " + (other.gameObject.tag == this.gameObject.tag));
//		Debug.Log ("tri " + !triggered);
//		Debug.Log ("val " + valid);
//		Debug.Log ((other.gameObject.tag == this.gameObject.tag) + ", " + !triggered + ", " + valid);

		if (other.gameObject.tag == this.gameObject.tag && !triggered && valid && other.gameObject.GetComponent<Shape> ().valid) {
			flashColor ();
			triggered = true;
		}
	}


		

//	void OnMouseDrag() {
////		if (Input.GetMouseButton (1)) {
////			transform.position = curPosPrev;
////			xDeg -= Input.GetAxis("Mouse X") * 10;
////			//yDeg += Input.GetAxis("Mouse Y") * 5;
////			Quaternion fromRotation = transform.rotation;
////			Quaternion toRotation = Quaternion.Euler(0,xDeg,0);
////			transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime * 5);
////		} else {
//			screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
//			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//			Vector3 curPos = Camera.main.ScreenToWorldPoint (curScreenPoint);
//			curPos.y = 1f;
//			transform.position = curPos;
//			curPosPrev = curPos;
//			dragged = true;
////		}
//	}

//	void OnDrawGizmos() {
//		Gizmos.color = Color.yellow;
//
//		Gizmos.DrawSphere (board.closestPoint(transform.position), 2f);
//	}
}