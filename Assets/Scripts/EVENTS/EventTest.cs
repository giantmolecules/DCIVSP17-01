using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

	private UnityAction someListener;

	void Awake ()
	{
		//someListener = new UnityAction (SomeFunction);
	}

	void OnEnable ()
	{
		EventManager.StartListening ("state01", SomeFunction);
		EventManager.StartListening ("state02", SomeOtherFunction);
		EventManager.StartListening ("state03", SomeThirdFunction);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("state01", SomeFunction);
		EventManager.StopListening ("state02", SomeOtherFunction);
		EventManager.StopListening ("state03", SomeThirdFunction);
	}

	void SomeFunction ()
	{
		Debug.Log (gameObject.name + "Reporting State 1 was called!");
	}

	void SomeOtherFunction ()
	{
		Debug.Log (gameObject.name + "Reporting State 2 was called!");
	}

	void SomeThirdFunction ()
	{
		Debug.Log (gameObject.name + "Reporting State 3 was called!");
	}
}