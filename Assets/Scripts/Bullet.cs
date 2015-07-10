using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	private Rigidbody rb;
	private MeshRenderer mr;
	
	//for particle rotation
	public Quaternion adj = Quaternion.Euler(0,0,90);
	public ParticleSystem boom;

	void Awake () {
		rb = this.GetComponent<Rigidbody>();
		mr = this.GetComponent<MeshRenderer>();

	}

	void Update () {
		transform.rotation = Quaternion.Euler(0,0,-90)*Quaternion.LookRotation(new Vector3(rb.velocity.x,rb.velocity.y,0));
	}

	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag != "Slingshot"){
		rb.Sleep();
		//mr.enabled = false;
		Instantiate (boom, transform.position,Quaternion.Euler(0,0,180)*transform.rotation); //adj*transform.rotation);
		FollowCam.Shake (.3f);
		Destroy (gameObject);
 		}
	}
}
