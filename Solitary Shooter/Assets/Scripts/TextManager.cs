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

	public PlayerController Player;

	//Sets up text to have default values
	void Start () {
		
		playerHealth.text = "100";
		killAmount.text = "Kills: 0";
		ammoClip.text = "10";
		totalBullets.text = "50";
		pKills = 0;
	}
	
	//Always check if health and ammo need updating
	void Update () {
		UpdateHealth ();
		UpdateAmmo ();
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
}
