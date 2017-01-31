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
		Debug.Log ("State 1 was called!");
		Renderer r = GetComponent<Renderer> ();
		r.material.color = new Color (255, 0, 0);
	}

	void SomeOtherFunction ()
	{
		Debug.Log ("State 2 was called!");
	}

	void SomeThirdFunction ()
	{
		Debug.Log ("State 3 was called!");
	}
}