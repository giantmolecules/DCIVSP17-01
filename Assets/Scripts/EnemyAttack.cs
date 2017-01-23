using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	AudioSource sound;
	AudioClip clip;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		sound = GetComponent<AudioSource > ();
		clip = GetComponent<AudioClip> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange) {
			Attack ();
		}
		if (playerHealth.currentHealth <= 0) {
			//player dead
		}
	}

	void Attack(){
		timer = 0f;
		if (playerHealth.currentHealth > 0) {
			sound.Play ();
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
