using UnityEngine;
using System.Collections;

public class CAWeather : MonoBehaviour {

	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnDrawGizmosSelected() {
		Vector3 center = rend.bounds.center;
		float radius = rend.bounds.extents.magnitude;
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(center, radius);
	}
}
