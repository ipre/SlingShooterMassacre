using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	private ParticleSystem ps;
	private AudioSource source;
	public AudioClip explosion;

	//put audio here due to destroy() in bullet script

	void Awake () {
		ps = GetComponent<ParticleSystem> ();
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (explosion);
	}

	void Update () {
		if (!ps.IsAlive()) {
			Destroy(gameObject);
		}
	}
}
