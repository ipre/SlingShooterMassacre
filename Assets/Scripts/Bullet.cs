using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	Rigidbody rb;
	MeshRenderer mr;
	public ParticleSystem boom;
	Quaternion vel = Quaternion.Euler(0,0,-90);
	Quaternion adj = Quaternion.Euler(0,0,90);

	// Use this for initialization
	void Awake () {
		rb = this.GetComponent<Rigidbody>();
		mr = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.magnitude > 1.0f){
			transform.rotation= vel*Quaternion.LookRotation(rb.velocity);
		}
	}

	void OnCollisionEnter () {
		rb.Sleep();
		//mr.enabled = false;
		Instantiate(boom, transform.position, adj*transform.rotation);
		Destroy (gameObject);

	}
}
