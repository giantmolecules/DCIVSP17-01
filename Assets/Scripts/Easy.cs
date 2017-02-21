using UnityEngine;
using System.Collections;

public class Easy : MonoBehaviour {

	public GameObject theObject;
	public static EasingFunction.Ease ease = EasingFunction.Ease.EaseInOutQuad;
	private EasingFunction.Function func = EasingFunction.GetEasingFunction(ease);
	private float time = 0;
	private float interval = 0;
	private float val = 0;
	public Transform startPos;

	// Use this for initialization
	void Start () {
		startPos = transform;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		interval = 10;
		float t = time % interval;
		float tn = t / interval;
		val = func (0, 10, tn);
		Debug.Log (val);
		theObject.transform.position = startPos.position +  new Vector3 (val, 0, 0);
	}
}
