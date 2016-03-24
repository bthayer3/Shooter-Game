//Broderick Thayer
using UnityEngine;
using System.Collections;

public class Boxcar : Enemy {
	

	//Set Boxcar enemy defaults
	void Start () {
		health = 30;
		movementSpeed = 10;
	}
	
	//Determine if enemy needs to die
	void Update () {
		base.CheckEnemyHealth ();
	}

	//Allow Boxcar enemy to inherit the collision code from the base class
	public override void OnTriggerEnter(Collider other){
		base.OnTriggerEnter (other);
	}

}
