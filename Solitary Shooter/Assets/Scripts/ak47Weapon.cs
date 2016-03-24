//Broderick Thayer
using UnityEngine;
using System.Collections;

public class ak47Weapon : Weapon {

	// Use this for changing gun default values
	void Start () {
		maxGunAmmo = 20;
		clipSize = 50;
		fireRate = 0.8f;
	}
	
	//Constantly check gun ammo to determine if player can reload
	void Update () {
		if (clipSize == 10) {
			canReload = false;
		}
	}

	/// <summary>
	/// Shoots the AK47
	/// </summary>
	public override void Shoot(){
		base.Shoot();
	}
	//clipsize was 5
	//maxgunammo was 2

	/// <summary>
	/// Reload the AK47 and calculate bullets
	/// </summary>
	public override void Reload(){
		if (maxGunAmmo > 0) {                                  //check if there is bullets to put in clip
			int bulletstoReplace = 10 - clipSize;              //get the amount of bullets to fill the gun magazine

			if (bulletstoReplace > maxGunAmmo) {               //use this to avoid getting negative numbers
				clipSize = clipSize + maxGunAmmo;        	   //add extra bullets to clip
				maxGunAmmo = 0;                                //set remaining bullets to 0
			} else {
				int newTotal = maxGunAmmo - bulletstoReplace;  //find remaining bullets

				maxGunAmmo = newTotal;                         //set remaining bullets to amount left
				clipSize = clipSize + bulletstoReplace;        //increase clip with more bullets
			}
		}
	}
}
