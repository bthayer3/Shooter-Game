//Broderick Thayer
using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float speed;

	//Moves the bullet like a projectile every frame
	void Update(){
		Vector3 v3 = transform.forward;
		v3.y = 0.0F;  //Locks the bullet y position so that it flies straight
		transform.Translate(v3 * -speed * Time.deltaTime, Space.World);
	}

	//Always destroys bullet no matter what it hits
	void OnTriggerEnter(Collider other){
		Destroy (gameObject);
	}
}
