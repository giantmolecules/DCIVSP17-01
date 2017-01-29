using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	public float dayRate;
	public bool dayNight;
	public bool cycle;
	private float rotation;
	Light sun;

	// Use this for initialization
	void Start () {
		sun = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (cycle) {
			rotation = Time.deltaTime * dayRate;
			//Debug.Log (rotation);
			sun.transform.Rotate (new Vector3 (rotation, 0, 0));
		} else if (dayNight) {
			sun.transform.eulerAngles = new Vector3 (90, 0, 0);
		} else {
			sun.transform.eulerAngles = new Vector3 (-90, 0, 0);
		}
	}
}
