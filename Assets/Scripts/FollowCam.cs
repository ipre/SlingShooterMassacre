using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public GameObject poi;
	public static FollowCam S; //Singleton FollowCam instance
	//private Vector3 velocity = Vector3.zero;

	private float CamZ;
	public float zoom = 1;
	public float easing = 0.05f;

	public Vector2 minXY;

	void Awake() {
		S = this;
		CamZ = transform.position.z;

	}

	void FixedUpdate() {
		if ( poi == null ){
			return;
		}

		if ( poi != null ){

		Vector3 destination = poi.transform.position;
		destination.z = CamZ;
		destination.x = Mathf.Max(minXY.x, destination.x);
	
		destination.y = Mathf.Max(minXY.y, destination.y);
		
		//transform.position = destination;
		//transform.position = Vector3.SmoothDamp(transform.position,destination,ref velocity,0.9f);
		transform.position = Vector3.Lerp (transform.position, destination, easing);

		this.GetComponent<Camera>().orthographicSize = 10 + destination.y;

		this.GetComponent<Camera>().orthographicSize = 10 + transform.position.y;
		}
	}
}
