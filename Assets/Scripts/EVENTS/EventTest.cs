using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

	private UnityAction someListener;

	void Start ()
	{
		//someListener = new UnityAction (SomeFunction);
		//hello
	}

	void OnEnable ()
	{
		EventManager.StartListening ("state01", StateFunction01);
		EventManager.StartListening ("state02", StateFunction02);
		EventManager.StartListening ("state03", StateFunction03);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("state01", StateFunction01);
		EventManager.StopListening ("state02", StateFunction02);
		EventManager.StopListening ("state03", StateFunction03);
	}

	void StateFunction01 ()
	{
		Debug.Log (gameObject.name + "Reporting State 1 was called!");
	}

	void StateFunction02 ()
	{
		Debug.Log (gameObject.name + "Reporting State 2 was called!");
	}

	void StateFunction03 ()
	{
		Debug.Log (gameObject.name + "Reporting State 3 was called!");
	}

	void Update(){

	}
}