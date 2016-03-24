//Broderick Thayer
using UnityEngine;
using System.Collections;

public class ump45Weapon : Weapon {

	// Use this for changing gun default values
	void Start () {
		maxGunAmmo = 75;
		clipSize = 15;
		fireRate = 0.5f;
	}
	
	//Constantly check gun ammo to determine if player can reload
	void Update () {
		if (clipSize == 15) {
			canReload = false;
		}
	}

	/// <summary>
	/// Shoots the UMP45
	/// </summary>
	public override void Shoot(){
		base.Shoot();
	}

	/// <summary>
	/// Reload the UMP45 and calculate bullets
	/// </summary>
	public override void Reload(){
		if (maxGunAmmo > 0) {                                  //check if there is bullets to put in clip
			int bulletstoReplace = 15 - clipSize;              //get the amount of bullets to fill the gun magazine

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
