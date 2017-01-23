using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayViewerComplete : MonoBehaviour {

	public float weaponRange = 50f;                       // Distance in Unity units over which the Debug.DrawRay will be drawn
	private Camera fpsCam;                                // Holds a reference to the first person camera
	private RaycastHit raycastHit;
	private Vector3 lineOrigin;
	private GameObject barrelEnd;
	private LineRenderer lr;
	private float shotDuration = 2f;
	private AudioSource audio;
	private Rigidbody rb;
	public AudioClip clip;
	public Text theText1;
	public Text theText2;


	void Start () 
	{
		fpsCam = GetComponentInChildren<Camera>();
		barrelEnd = GameObject.Find ("GunBarrel");
		lr = gameObject.GetComponent<LineRenderer> ();
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource> ();
		audio.clip = clip;
		lr.SetVertexCount (2);
		lr.SetWidth (0.1f, 0.01f);

	}


	void FixedUpdate ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			
			StartCoroutine (ShotEffect ());

			lr.SetPosition (0, barrelEnd.transform.position);

			lineOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, fpsCam.nearClipPlane));

			if (Physics.Raycast (lineOrigin, fpsCam.transform.forward, out raycastHit)) {
				theText1.color = new Color (255, 0, 0);
				theText1.text = raycastHit.distance.ToString ();
				theText2.text = raycastHit.collider.gameObject.name;
				if (raycastHit.rigidbody != null) {
					raycastHit.rigidbody.AddExplosionForce (1000f, raycastHit.point, 50f);
					rb.AddRelativeForce (transform.forward*-100f);
				}
				lr.SetPosition (1, raycastHit.point);
			} else {
				theText1.color = new Color (0, 0, 255);
				theText2.text = "---";
				lr.SetPosition (1, lineOrigin + fpsCam.transform.forward * weaponRange);
			}

			//Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);

		}
	}
	private IEnumerator ShotEffect()
	{
		audio.clip = clip;
		audio.Play ();

		lr.enabled = true;

		yield return shotDuration;

		lr.enabled = false;
	}
}
