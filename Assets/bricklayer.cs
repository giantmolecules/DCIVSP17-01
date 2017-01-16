using UnityEngine;
using System.Collections;

public class bricklayer : MonoBehaviour {
	public GameObject brick;
	// Use this for initialization
	void Start () {
		for (int n = 0; n < 1000; n++) {
				float posX = Random.Range (0, 1000);
				float posY = Random.Range (0, 10);
				float posZ = Random.Range (0, 1000);
				Instantiate(brick, new Vector3(posX, posY, posZ), Quaternion.identity);
				Rigidbody brickBody = brick.AddComponent<Rigidbody> ();
				brickBody.mass = 1.0f;
			}
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}