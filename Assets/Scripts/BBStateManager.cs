using UnityEngine;
using System.Collections;

public class BBStateManager : MonoBehaviour {

	private GameObject[] State01;
	private GameObject[] State02;
	private GameObject[] State03;

	private State01 state01;
	private State02 state02;
	private State03 state03;

	private bool isActive;

	// Use this for initialization
	void Start () {

		State01 = GameObject.FindGameObjectsWithTag ("State01");
		State02 = GameObject.FindGameObjectsWithTag ("State02");
		State03 = GameObject.FindGameObjectsWithTag ("State03");


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
