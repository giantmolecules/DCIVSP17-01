using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public float force;
	public float radius;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Debug.Log ("KEYDOWN");
			//ExplosionDamage (transform.position, 10f);
			explode(radius, force);
		}
	}
	void ExplosionDamage(Vector3 center, float radius) {
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length) {
			Rigidbody rb = hitColliders [i].GetComponent<Rigidbody>();
			rb.AddExplosionForce (force, transform.position, 10f);
			i++;
		}
	}
	void explode(float radius, float power){
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
				rb.AddExplosionForce(power, transform.position, radius, 3.0F);

		}
	}
}
