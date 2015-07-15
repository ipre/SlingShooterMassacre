using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	private ParticleSystem ps;

	//put audio here due to destroy() in bullet script
	private AudioSource source;
	public AudioClip explosion;

	//explosion
	public float radius = 10.0f;
	public float power = 600.0f;

	void Awake () {
		ps = GetComponent<ParticleSystem> ();
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (explosion);

		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rbs = hit.GetComponent<Rigidbody> ();	
			if (rbs != null)
				rbs.AddExplosionForce (power, transform.position, radius, 3.0F);
		}
	}

	void Update () {
		if (!ps.IsAlive()) {
			Destroy(gameObject);
		}
	}
}
