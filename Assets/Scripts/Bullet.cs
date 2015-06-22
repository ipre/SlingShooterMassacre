using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Awake () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion vel = Quaternion.Euler(0,0,-90);
		transform.rotation= vel*Quaternion.LookRotation(rb.velocity);
	}

	void OnCollisionEnter () {
		Destroy (gameObject);
	}
}
