using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {

	public string filepath;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			Application.CaptureScreenshot(filepath);
		}
	}
}
