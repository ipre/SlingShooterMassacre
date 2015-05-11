using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public GameObject poi;
	public static FollowCam S; //Singleton FollowCam instance
	private Vector3 velocity = Vector3.zero;
	private float CamZ;
	public float zoom = 1;

	void Awake() {
		S = this;
		CamZ = transform.position.z-200;
	}

	void FixedUpdate() {
		if ( poi == null ){
			return;
		}

		if ( poi != null ){
		Vector3 destination = poi.transform.position;
		destination.z = CamZ;
			zoom+=0.05f;
		//transform.position = destination;
		//transform.position = Vector3.SmoothDamp(transform.position,destination,ref velocity,0.9f);
		transform.position = Vector3.Lerp (transform.position, destination, 0.05f);

			this.GetComponent<Camera>().orthographicSize= Mathf.Lerp (10,20,Mathf.Sin(zoom));

			//modeling clouds and background assets  +  size + max y so u dont see under map

		}
	}
}
