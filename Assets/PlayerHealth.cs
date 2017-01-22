using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f);

	AudioSource playerAudio;
	bool isDead;
	bool damaged;

	// Use this for initialization
	void Start () {
		playerAudio = GetComponent<AudioSource> ();
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		playerAudio.Play ();
		if (currentHealth <= 0 && !isDead) {
			Death ();
		}
	}

	void Death(){
		isDead = true;
		playerAudio.clip = deathClip;
		playerAudio.Play ();
	}
}
