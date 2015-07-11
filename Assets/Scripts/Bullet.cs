using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	private Rigidbody rb;
	private MeshRenderer mr;
	
	//for particle rotation
	public Quaternion adj = Quaternion.Euler(0,0,90);
	public GameObject explosion;
	private GameObject boom;



	void Awake () {
		rb = this.GetComponent<Rigidbody>();
		mr = this.GetComponent<MeshRenderer>();

	}

	void Update () {
		transform.rotation = Quaternion.LookRotation(rb.velocity)*Quaternion.Euler(-90,0,180);
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag != "Slingshot") {
			rb.Sleep ();
			//mr.enabled = false;
			boom = Instantiate (explosion, transform.position, Quaternion.Euler (0, 0, 180) * transform.rotation) as GameObject; //adj*transform.rotation);
			FollowCam.Shake (.3f);
			FollowCam.S.poi = boom;
			Destroy (gameObject);
		}
	}
}
