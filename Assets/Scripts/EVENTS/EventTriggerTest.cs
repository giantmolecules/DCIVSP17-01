using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour {


	void Update () {
		if (Input.GetKeyDown ("1"))
		{
			Debug.Log ("Pressed: 1");
			EventManager.TriggerEvent ("state01");
		}

		if (Input.GetKeyDown ("2"))
		{
			Debug.Log ("Pressed: 2");
			EventManager.TriggerEvent ("state02");
		}

		if (Input.GetKeyDown ("3"))
		{
			Debug.Log ("Pressed: 3");
			EventManager.TriggerEvent ("state03");
		}
	}
}