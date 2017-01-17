using UnityEngine;
using System.Collections;

	public class Raycast : MonoBehaviour 
	{
		void FixedUpdate() 
		{
			Vector3 fwd = transform.TransformDirection(Vector3.forward);

			if (Physics.Raycast(transform.position, fwd)) 
				print("There is something in front of the object!");
		}
	}
