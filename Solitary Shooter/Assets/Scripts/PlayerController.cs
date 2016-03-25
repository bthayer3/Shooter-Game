//Broderick Thayer
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {


	private Vector3 moveDirection = Vector3.zero;
	public Animator anim;               // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

	private bool Crouched;
	private bool Running;
	private bool switchingWeapon;
	private bool Reloading;
	private bool Death;
	private bool couldReload;
	private bool hasGun;

	public CapsuleCollider col1;
	public CapsuleCollider col2;

	public GameObject AK47;
	public GameObject UMP45;
	public GameObject M4A1;
	public GameObject groundAk;
	public GameObject groundUmp;
	public GameObject groundM4;
	public Text grabWeapon1;
	public Text grabWeapon2;
	public Text grabWeapon3;

	private int currentWeapon;
	private int movementSpeed;
	private int turnSpeed;
	private int playerHealth;
	public int ammoinClip;
	public int bulletsRemaining;


	public float Horizontal;
	public float Vertical;
	private float inputH;
	private float inputV;
	private float nextFire1;
	private float nextFire2;
	private float nextFire3;
	private List<GameObject> foundWeapons;

	private Color color;
	public Text learnedCrouch;

	void Start ()
	{		
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		Death = false;
		switchingWeapon=false;
		Reloading = false;
		Crouched = false;
		Running = false;
		col2.enabled = false;
		couldReload = false;
		hasGun = false;

		playerHealth = 100;
		currentWeapon = 0;
		turnSpeed = 300;

		AK47.SetActive(false);
		UMP45.SetActive (false);
		M4A1.SetActive (false);
		grabWeapon1.text = "";
		grabWeapon2.text = "";
		grabWeapon3.text = "";
//		grabWeapon1.enabled = false;
//		grabWeapon2.enabled = false;
//		grabWeapon3.enabled = false;
		//grabWeapon.enabled = false;
		learnedCrouch.text = "";

		foundWeapons = new List<GameObject>();

		//color = Color.white;
	
	}

	void Update ()
	{
		if (Death == false) { //Does not execute update code if player is dead
			Death = false;   //Keeps death constant for death animation

			//Gets keyboard input and passes into variables
			inputH = Input.GetAxis ("Horizontal");  
			inputV = Input.GetAxis ("Vertical");

			//Helps animations transition smoothly
			Horizontal = Mathf.Lerp (Horizontal, inputH, Time.smoothDeltaTime * 8);   
			Vertical = Mathf.Lerp (Vertical, inputV, Time.smoothDeltaTime * 8);

			//Sets the parameters for the animation controller
			anim.SetFloat ("inputH", Horizontal);
			anim.SetFloat ("inputV", Vertical);
			anim.SetBool ("IsCrouched", Crouched);
			anim.SetBool ("Wantstorun", Running);
			anim.SetBool ("Dead", Death);
			anim.SetBool ("FoundGun", hasGun);


			DetermineMovementSpeed ();
			Turn ();
			Move ();

			//float dist1 = Vector3.Distance (groundAk.transform.position, transform.position);
			//float dist2 = Vector3.Distance (groundUmp.transform.position, transform.position);
			//float dist3 = Vector3.Distance (groundM4.transform.position, transform.position);

			//print ("the count of weapons found is " + foundWeapons.Count);
//			if (!AK47.activeSelf) {
//				print ("the ak47 weapon has not been grabbed yet");
//			} else {
//				print ("the weapon has been picked up");
//			}

			if (foundWeapons.Count >= 1) {
				hasGun = true;
				//learnedCrouch.text = "You have learned crouch, press left control to crouch";
				//if(foundWeapons [currentWeapon].name == "Ak-47"){
				//	print ("first weapon is ak");
				//}
				//print (foundWeapons [0].name);
				//Fade.use.Alpha(learnedCrouch, 1.0, 0.0, 3.0);
//				while (learnedCrouch.material.color.a > 0){
//					learnedCrouch.material.color.a -= 0.1F * Time.deltaTime * 2;
//					yield return 0;
//				}

			}
			float dist1 = Vector3.Distance (groundAk.transform.position, transform.position);
			float dist2 = Vector3.Distance (groundUmp.transform.position, transform.position);
			float dist3 = Vector3.Distance (groundM4.transform.position, transform.position);

			if (!AK47.activeSelf) {
				
				if (dist1 < 1) {
					//grabWeapon1.enabled = true;
					grabWeapon1.text = "Press 'G' to grab AK-47";
					//print ("it got here");
					if (Input.GetKeyUp (KeyCode.G)) {
						anim.Play ("Grabgun", -1, 0f);
						StartCoroutine (DelayforGrab (0.6f, 1));
						foundWeapons.Add (AK47);
						//hasweapon = true;
						//grabWeapon1.enabled = false;
						Destroy(grabWeapon1);
						//grabWeapon1.text = "";
					}
				} else {
					grabWeapon1.text = "";
					//grabWeapon1.enabled = false;
				}
			}

			if (!UMP45.activeSelf) {
				
				if (dist2 < 1) {
					//grabWeapon2.enabled = true;
					grabWeapon2.text = "Press 'G' to grab UMP-45";
					//print ("it got here 2");
					if (Input.GetKeyUp (KeyCode.G)) {
						anim.Play ("Grabgun", -1, 0f);
						StartCoroutine (DelayforGrab (0.6f, 2));
						foundWeapons.Add (UMP45);
						//hasweapon = true;
						//grabWeapon2.enabled = false;
						//grabWeapon2.text = "";
						Destroy(grabWeapon2);
					}
				} else {
					grabWeapon2.text = "";
					//grabWeapon2.enabled = false;
				}
			}

			if (!M4A1.activeSelf) {
				
				if (dist3 < 1) {
					//grabWeapon3.enabled = true;
					grabWeapon3.text = "Press 'G' to grab M4A1";
					//print ("it got here 3");
					if (Input.GetKeyUp (KeyCode.G)) {
						anim.Play ("Grabgun", -1, 0f);
						StartCoroutine (DelayforGrab (0.6f, 3));
						foundWeapons.Add (M4A1);
						//hasweapon = true;
						//grabWeapon3.enabled = false;
						//grabWeapon3.text = "";
						Destroy(grabWeapon3);
					}
				} else {
					grabWeapon3.text = "";
					//grabWeapon3.enabled = false;
				}
			}


//			if ((dist1 < 1) || (dist2 < 1) || (dist3 < 1)) {
//				//print ("A gun is in range to pickup");
//				grabWeapon.text = "Press 'G' to grab weapon";
//			}
//			else{
//				//print("A gun is not in range");
//				grabWeapon.text = "";
//			}
					


			if (Input.GetKey (KeyCode.LeftShift)) {  //Allows player to run while holding down left shift
				Running = true;
			}

			if (Input.GetKeyUp (KeyCode.LeftShift)) { //Turn off running if user stop pressing left shift
				Running = false;
			}


			if (hasGun == true) {
				GetCurrentWeaponInfo ();


				if (Crouched == true && Running == true) { //Allows player to change from crouching to running
					Crouched = false;
					Running = true;
				}


				if (Input.GetKeyUp (KeyCode.LeftControl)) {  //Toggles Crouching
					Crouched = !Crouched;
				}

				//Handles colliders for player depending on whether he is crouching or not
				if (Crouched == true) {
					col2.enabled = true;
					col1.enabled = false;
				} else if (Crouched == false) {
					col1.enabled = true;
					col2.enabled = false;
				}


				//If user wants to switch weapon
				if (foundWeapons.Count > 1) {
					if (Input.GetKeyUp (KeyCode.Q)) {
						anim.SetLayerWeight (2, 0);
						anim.SetLayerWeight (1, 1);
						anim.Play ("grab_rifle_from_behind_shoulder", 1, 0f);

						StartCoroutine (WaitToChange (0.24f));
						StartCoroutine (DelayforAnimation (1.61f));
					}
				}

				//If user wants to reload
				if (Input.GetKeyUp (KeyCode.R)) {     
					if (bulletsRemaining > 0 && couldReload == true) {
						anim.SetLayerWeight (1, 0);
						anim.SetLayerWeight (2, 1);
						anim.Play ("reload_2", 2, 0f);
						StartCoroutine (DelayforAnimation (1.61f));
						ReloadCurrentGun ();
					}

				} 
				if (Reloading == false && switchingWeapon == false) {
					if (foundWeapons [currentWeapon].name == "Ak-47") {
						if (Input.GetMouseButton (0)) {         //Automatic cause of holding down
							//Get the inherited shoot method from the script and call it
							ak47Weapon Action = AK47.GetComponent<ak47Weapon> ();
							Action.Shoot ();
						}
					}

					if (foundWeapons [currentWeapon].name == "UMP-45") {

						if (Input.GetMouseButton (0)) {         //Automatic cause of holding down
							//Get the inherited shoot method from the script and call it
							ump45Weapon Action2 = UMP45.GetComponent<ump45Weapon> ();
							Action2.Shoot ();
						}		
					}

					if (foundWeapons [currentWeapon].name == "M4A1 Sopmod") {
						if (Input.GetMouseButtonUp (0)) {       //Use ButtonUp makes it semi-automatic
							//Get the inherited shoot method from the script and call it
							m4a1Weapon Action3 = M4A1.GetComponent<m4a1Weapon> ();
							Action3.Shoot ();
						}
					}
				}

				//Checks if reloading animation is playing so that the bool can be modified correctly
				if (anim.GetCurrentAnimatorStateInfo (2).IsName ("reload_2")) {
					Reloading = true;
				} else {
					Reloading = false;
				}

				//Checks if switching animation is playing so that the bool can be modified correctly
				if (anim.GetCurrentAnimatorStateInfo (1).IsName ("grab_rifle_from_behind_shoulder")) {
					switchingWeapon = true;	
				} else {
					switchingWeapon = false;
				}
			}

		}

		//Shows forward direction of player
		//Debug.DrawRay (transform.position, transform.forward * 10, Color.red);
	}


	/// <summary>
	/// Grabs the health value for the text manager script to access
	/// </summary>
	/// <value>The health.</value>
	public int Health{
		get{ return playerHealth; }
		set{ playerHealth = value; }
	}

	/// <summary>
	/// Smoothens the weapon change animation so that it appears more realistic
	/// </summary>
	/// <returns>The to change.</returns>
	/// <param name="delay">Delay.</param>
	IEnumerator WaitToChange(float delay)
	{
		yield return new WaitForSeconds(delay);
		ChangeWeapon ();

	}


	/// <summary>
	/// Lets animation finish and resets layer weights
	/// </summary>
	/// <returns>The animation.</returns>
	/// <param name="delay">Delay.</param>
	IEnumerator DelayforAnimation(float delay)
	{
		yield return new WaitForSeconds(delay);
		anim.SetLayerWeight (2, 0);
		anim.SetLayerWeight (1, 0);
	}

	IEnumerator DelayforGrab(float delay, int gunNum)
	{
		yield return new WaitForSeconds(delay);

		if (gunNum == 1) {
			AK47.SetActive (true);
			groundAk.SetActive (false);
		}

		if (gunNum == 2) {
			UMP45.SetActive (true);
			groundUmp.SetActive (false);
		}

		if (gunNum == 3) {
			M4A1.SetActive (true);
			groundM4.SetActive (false);
		}
	}

	/// <summary>
	/// Determines the movement speed based off what the player wants to do.
	/// </summary>
	void DetermineMovementSpeed(){
		if (Running == true) {
			movementSpeed = 12;		//Running Speed
		} else if (Crouched == true) {
			movementSpeed = 4;    //Crouching Speed
		} else {
			movementSpeed = 8;   //Walking Speed
		}
	}


	/// <summary>
	/// Reloads the current gun based off the inherited reload method.
	/// </summary>
	void ReloadCurrentGun(){
		if (foundWeapons [currentWeapon].name == "Ak-47") {
			ak47Weapon Action1 = AK47.GetComponent<ak47Weapon> (); 
			Action1.Reload ();
		}

		if (foundWeapons [currentWeapon].name == "UMP-45") {
			ump45Weapon Action2 = UMP45.GetComponent<ump45Weapon> ();
			Action2.Reload ();
		}

		if (foundWeapons [currentWeapon].name == "M4A1 Sopmod") {
			m4a1Weapon Action3 = M4A1.GetComponent<m4a1Weapon> ();
			Action3.Reload ();
		}
	}

	/// <summary>
	/// Extracts ammo and reloading information of each individual weapon from their script
	/// </summary>
	void GetCurrentWeaponInfo(){
		if (foundWeapons [currentWeapon].name == "Ak-47") {
			ammoinClip = AK47.GetComponent<ak47Weapon> ().Clipsize;
			bulletsRemaining = AK47.GetComponent<ak47Weapon> ().MaxgunAmmo;
			couldReload = AK47.GetComponent<ak47Weapon> ().Canreload;
		}

		if (foundWeapons [currentWeapon].name == "UMP-45") {
			ammoinClip = UMP45.GetComponent<ump45Weapon> ().Clipsize;
			bulletsRemaining = UMP45.GetComponent<ump45Weapon> ().MaxgunAmmo;
			couldReload = UMP45.GetComponent<ump45Weapon> ().Canreload;
		}

		if (foundWeapons [currentWeapon].name == "M4A1 Sopmod") {
			ammoinClip = M4A1.GetComponent<m4a1Weapon> ().Clipsize;
			bulletsRemaining = M4A1.GetComponent<m4a1Weapon> ().MaxgunAmmo;
			couldReload = M4A1.GetComponent<m4a1Weapon> ().Canreload;
		}
	}


	/// <summary>
	/// Handles the game over if the player dies
	/// </summary>
	void HandleGameOver(){
		if (playerHealth <= 0) {
			playerHealth = 0;
			col1.enabled = false;
			col2.enabled = false;
			Death = true;
			Time.timeScale = 0;	//pauses game once player is dead
		}
	}

	/// <summary>
	/// Minus player health depending on what enemy hit him
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Boxcar")
		{
			playerHealth -=5;
		}

		if (other.gameObject.tag == "Cylinder")
		{
			playerHealth -= 10;
		}

		if (other.gameObject.tag == "Pacman")
		{
			playerHealth -= 15;
		}
	}


	/// <summary>
	/// Changes the current weapon of the player to the next weapon
	/// </summary>
	void ChangeWeapon(){
		foundWeapons [currentWeapon].SetActive (false);
		currentWeapon++;
		if (currentWeapon >= foundWeapons.Count) {
			currentWeapon = 0;
		}
		foundWeapons [currentWeapon].SetActive (true);
//		if (currentWeapon > 3) {     //reset counter back to beginning
//			currentWeapon = 1;
//		}
//
//		if (currentWeapon == 1) {
//			AK47.SetActive(true);    //show the first weapon
//			UMP45.SetActive (false);
//			M4A1.SetActive (false);
//		}
//
//		if (currentWeapon == 2) {
//			AK47.SetActive(false);
//			UMP45.SetActive (true);  //show the second weapon
//			M4A1.SetActive (false);   
//		}
//
//		if (currentWeapon == 3) {
//			AK47.SetActive(false);
//			UMP45.SetActive (false);
//			M4A1.SetActive (true);   //show the last weapon
//		}
	}


	/// <summary>
	/// Rotates the player based off mouse movement
	/// </summary>
	private void Turn(){
		float MouseX = Input.GetAxis ("Mouse X");
		float turn = MouseX * turnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		playerRigidbody.MoveRotation (playerRigidbody.rotation * turnRotation);
	
	}

	/// <summary>
	/// Moves the player depending on his speed, forward direction, and inputs
	/// </summary>
	private void Move (){
		moveDirection = new Vector3(inputH, 0, inputV);                  //Create a Vector3 based off keyboard inputs
		moveDirection = transform.TransformDirection(moveDirection);     //Fix forward direction of the player
		moveDirection *= movementSpeed * Time.deltaTime;                 //Multiply in his speed and game time
		playerRigidbody.velocity = moveDirection * 40;                   //Move the player based off move direction
	}	

//	void Fade(){
//
//		while (learnedCrouch.material.color.a > 0){
//			learnedCrouch.material.color.a -= 0.1F * Time.deltaTime * 2;
//			yield return 0;
//		}
//		//Destroy (learnedCrouch);
//	}
}
