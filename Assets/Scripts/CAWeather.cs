using UnityEngine;
using System.Collections;

public class CAWeather : MonoBehaviour {

	private Renderer rend;
	private bool[] neighbors;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		neighbors = new bool[16];
		//for (int i = 0; i < neighbors. ; i++) {
		//	neighbors [i] = Random.Range (0, 2);
		//}
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
