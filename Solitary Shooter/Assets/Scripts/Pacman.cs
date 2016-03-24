//Broderick Thayer
using UnityEngine;
using System.Collections;

public class Pacman : Enemy {


	//Set Pacman enemy defaults
	void Start () {
		health = 60;
		movementSpeed = 5;
	}
	
	//Determine if enemy needs to die
	void Update () {
		base.CheckEnemyHealth ();
	}

	//Allow Pacman enemy to inherit the collision code from the base class
	public override void OnTriggerEnter(Collider other){
		base.OnTriggerEnter (other);
	}
}
