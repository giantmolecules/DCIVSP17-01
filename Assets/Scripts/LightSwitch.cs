using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {

	public Light theLight;
	public float flickerDuration;
	private float flickerTime;
	public float maxIntensity;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		theLight.intensity = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(){
		Debug.Log ("On");
		//theLight.intensity = 1.5f;
		coroutine = flickerOn();
		StartCoroutine(coroutine);
	}

	void OnTriggerStay(){
		theLight.intensity = 3f;
	}

	void OnTriggerExit(){
		Debug.Log ("Off");
		theLight.intensity = 0f;
		flickerTime = 0f;
	}

	IEnumerator flickerOn(){
		while (flickerTime < flickerDuration) {
			flickerTime += Time.deltaTime;
			int state = Random.Range (0, 2);
			theLight.intensity = state;
			//yield return new WaitForSeconds(Random.Range(0,1));
			yield return null;
		}

		Debug.Log ("Max");
	}
}
