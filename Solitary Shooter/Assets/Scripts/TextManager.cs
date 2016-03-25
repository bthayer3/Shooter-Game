//Broderick Thayer
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	public Text playerHealth;
	public Text killAmount;
	public Text ammoClip;
	public Text totalBullets;
	private int pKills;

	private float duaration;
	private Color color;
	public Text learnedCrouch;

	public PlayerController Player;
	private bool lCrouch;

	//Sets up text to have default values
	void Start () {
		
		playerHealth.text = "100";
		killAmount.text = "Kills: 0";
		ammoClip.text = "10";
		totalBullets.text = "50";
		pKills = 0;
		learnedCrouch.text = "";
	}
	
	//Always check if health and ammo need updating
	void Update () {
		UpdateHealth ();
		UpdateAmmo ();

		lCrouch = Player.learnedCrouch;
		if (lCrouch == true) {
			learnedCrouch.text = "You have learned crouch, press left control to crouch";
			Color myColor = learnedCrouch.color;
			color = Color.Lerp (myColor, Color.clear, .15f * Time.deltaTime);
//			float ratio = Time.time / 5.0f;
//			myColor.a = Mathf.Lerp (1, 0, ratio);
			learnedCrouch.color = color;
			StartCoroutine (WaittoHide (5.0f));
			lCrouch = false;
		}
	}

	/// <summary>
	/// Updates the kill amount and on-screen text.
	/// </summary>
	public void UpdateKills(){   //called from enemy script
		pKills++;
		killAmount.text = "Kills: " + pKills.ToString ();
	}

	/// <summary>
	/// Updates player health text on-screen.
	/// </summary>
	public void UpdateHealth(){
		playerHealth.text = Player.Health.ToString ();
	}

	/// <summary>
	/// Updates the ammo text on-screen for the current weapon in use
	/// </summary>
	public void UpdateAmmo(){
		ammoClip.text = Player.ammoinClip.ToString ();
		totalBullets.text = "/ " + Player.bulletsRemaining.ToString ();
	}

	IEnumerator WaittoHide(float delay)
	{
		yield return new WaitForSeconds(delay);
		//Destroy (learnedCrouch);
		learnedCrouch.enabled = false;

	}
}
