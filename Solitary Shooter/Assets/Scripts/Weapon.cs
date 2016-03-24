//Broderick Thayer
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	protected int clipSize;
	protected int maxGunAmmo;
	protected float fireRate;
	protected bool canReload;
	protected float nextFire;  
	public GameObject Bullet;
	public Transform bulletSpawn;

    
	public int Clipsize{
		get{ return clipSize; }
		set{ clipSize = value; }
	}

	public int MaxgunAmmo{
		get{ return maxGunAmmo; }
		set{ maxGunAmmo = value; }
	}

	public float Firerate{
		get{ return fireRate; }
		set{ fireRate = value; }
	}

	public bool Canreload{
		get{ return canReload; }
		set{ canReload = value; }
	}


	/// <summary>
	/// Shoots gun depending on ammo and fire rate
	/// </summary>
	public virtual void Shoot(){
		if ((Time.time > nextFire) && (clipSize > 0)) {
			nextFire = Time.time + fireRate;		
			Instantiate (Bullet, bulletSpawn.position, bulletSpawn.rotation);
			clipSize--;
			canReload = true;
		}
	}

	public virtual void Reload(){
		
	}
}
