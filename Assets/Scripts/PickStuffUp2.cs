using UnityEngine;
using System.Collections;

public class PickStuffUp2 : MonoBehaviour {

	RaycastHit hit;
	private Camera fpsCam;

	private Vector3 lineOrigin;
	private bool move;
	private bool pickedSomethingUp;
	private Vector3 fromPoint;
	private Vector3 toPoint;
	private float journeyLength;
	private float pointAlongTheWay;
	private float distance;
	public float speed = 1.0F;
	public float weaponRange = 50f;  
	private GameObject target;// Distance in Unity units over which the Debug.DrawRay will be drawn
	private Rigidbody rigidBody;
	private Collider collider;


	// Use this for initialization
	void Start () {
		move = false;
		pickedSomethingUp = false;
		fpsCam = GetComponentInChildren<Camera>();
		toPoint = transform.position;
	}

	// Update is called once per frame
	void Update () {

		toPoint = transform.position;

		lineOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, fpsCam.nearClipPlane));

		if (Physics.Raycast (lineOrigin, fpsCam.transform.forward, out hit)) {
			if(Input.GetKey(KeyCode.P)){
				target = GameObject.Find (hit.collider.gameObject.name);
				rigidBody = target.GetComponent<Rigidbody> ();
				collider = target.GetComponent<Collider> ();
				move = true;
			}
		}

		if (move == true) {
			fromPoint = target.transform.position;
			rigidBody.AddForce (toPoint - fromPoint, ForceMode.Acceleration);
		}

		distance = Vector3.Distance(fromPoint, toPoint);
		Debug.Log ("Dist: " + distance);

		if (distance < 5f && move == true) {
			move = false;
			rigidBody.isKinematic = true;
			target.transform.SetParent (transform);
			target.transform.localPosition = new Vector3 (0, 0, collider.bounds.size.z);
		}

		if (Input.GetKey (KeyCode.O)) {
			target.transform.SetParent (null);
			rigidBody.isKinematic = false;
			rigidBody.AddForce ((fromPoint - toPoint)*10, ForceMode.Acceleration);
		}
	}
}
