using UnityEngine;
using System.Collections;

public class Easy : MonoBehaviour {

	public static EasingFunction.Ease ease = EasingFunction.Ease.EaseInOutQuad;
	private EasingFunction.Function func = EasingFunction.GetEasingFunction(ease);
		

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
