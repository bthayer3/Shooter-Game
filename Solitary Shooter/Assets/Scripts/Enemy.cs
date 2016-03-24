//Broderick Thayer
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	protected int health;
	protected int attackDamage;
	protected int movementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//CheckEnemyHealth ();
	}

	public int Health{
		get{ return health; }
		set{ health = value; }
	}

	public int Attackdamage{
		get{ return attackDamage; }
		set{ attackDamage = value; }
	}

	public int Movementspeed{
		get{ return movementSpeed; }
		set{ movementSpeed = value; }
	}


	/// <summary>
	/// Handle Collisions with the different bullets
	/// </summary>
	/// <param name="other">Other.</param>
	public virtual void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "akbullet")
		{
			health -= 10;
			Destroy(other.gameObject);   //Destroy bullet that hit enemy
		}

		if (other.gameObject.tag == "m4bullet")
		{
			health -= 20;
			Destroy(other.gameObject);   //Destroy bullet that hit enemy
		}

		if (other.gameObject.tag == "umpbullet")
		{
			health -= 5;
			Destroy(other.gameObject);   //Destroy bullet that hit enemy
		}

	}


	/// <summary>
	/// Checks enemy health determining whether the enemy needs destroyed and handles updating kills
	/// </summary>
	public virtual void CheckEnemyHealth(){
		if (health <= 0) {
			Destroy(gameObject);   //destroys the dead enemy
			TextManager Display = GameObject.FindGameObjectWithTag ("Tmanager").GetComponent<TextManager> ();   //Sets up the reference
			Display.UpdateKills ();   //Updates kills in TextManager script
		}
	}
}
