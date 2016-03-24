//Broderick Thayer
using UnityEngine;
using System.Collections;

public class CylinderEnemy : Enemy {
	

	//Set Cylinder enemy defaults
	void Start () {
		health = 40;
		movementSpeed = 8;
	}
	
	//Determine if enemy needs to die
	void Update () {
		base.CheckEnemyHealth ();
	}

	//Allow Cylinder enemy to inherit the collision code from the base class
	public override void OnTriggerEnter(Collider other){
		base.OnTriggerEnter (other);
	}
}
