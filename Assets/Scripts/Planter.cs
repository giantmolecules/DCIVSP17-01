using UnityEngine;
using System.Collections;

public class Planter : MonoBehaviour {

	public GameObject go;
	public float  spacing;
	public float numX;
	public float numY;
	public float offset;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numX; i++) {
			for (int j = 0; j < numY; j++) {
				Instantiate (go,new Vector3 (i * spacing + offset, 50, j*spacing + offset),Quaternion.identity,transform);
				//go.transform.position = new Vector3 (i * spacing, j*spacing, 0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
