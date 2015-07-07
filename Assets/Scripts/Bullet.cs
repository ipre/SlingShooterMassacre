using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody rb;
	MeshRenderer mr;

	// Use this for initialization
	void Awake () {
		rb = this.GetComponent<Rigidbody>();
		mr = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.magnitude > 1.0f){
			Quaternion vel = Quaternion.Euler(0,0,-90);
			transform.rotation= vel*Quaternion.LookRotation(rb.velocity);
		}
	}

	void OnCollisionEnter () {
		rb.Sleep();
		//mr.enabled = false;
		Destroy (gameObject,0.2f);

	}
}
