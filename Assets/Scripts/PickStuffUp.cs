using UnityEngine;
using System.Collections;

public class PickStuffUp : MonoBehaviour {

	RaycastHit hit;
	private Camera fpsCam;

	private Vector3 lineOrigin;
	private bool move;
	private bool pickedSomethingUp;
	private Vector3 fromPoint;
	private Vector3 toPoint;
	private float journeyLength;
	private float pointAlongTheWay;
	private float distCovered;
	public float speed = 1.0F;
	public float weaponRange = 50f;                       // Distance in Unity units over which the Debug.DrawRay will be drawn


	// Use this for initialization
	void Start () {
		move = false;
		pickedSomethingUp = false;
		fpsCam = GetComponentInChildren<Camera>();
		toPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		lineOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, fpsCam.nearClipPlane));
		if (Physics.Raycast (lineOrigin, fpsCam.transform.forward, out hit)) {
			if(Input.GetKey(KeyCode.P)){
				Debug.Log (hit.collider.gameObject.name);
				GameObject target = GameObject.Find (hit.collider.gameObject.name);
				fromPoint = target.transform.position;
				move = true;
				pickedSomethingUp = true;
				journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
			}
		}
		if (move == true) {
			distCovered += Time.deltaTime * speed;
			pointAlongTheWay = distCovered / journeyLength;
			target.transform.position = Vector3.Lerp (fromPoint, toPoint, pointAlongTheWay);
		}
		target.transform.SetParent (transform);
	}
}
