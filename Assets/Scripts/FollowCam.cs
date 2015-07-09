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

	private GameObject startPos;
	Vector3 destination;
	float timer=0.0f;


	void Awake() {
		S = this;
		CamZ = transform.position.z;
		startPos = GameObject.FindGameObjectWithTag("Slingshot");
	}

	void FixedUpdate() {	

		// Check if the poi exists
		if(poi == null) {
			timer+= 1.0f * Time.deltaTime;
			// set the destination to the slingshot (zero  vector)
			//after a delay of 1.5seconds
			if(timer>1.0f)
				destination = Vector3.zero;
		} else {

			// else (there is a poi)			
			destination = poi.transform.position;
			
			// is the poi a projectile ?
			if(poi.tag == "Projectile") {
				timer = 0;
				// check if it is resting (sleeping)
				if(poi.GetComponent<Rigidbody>().IsSleeping()  ){
					
					// set the poi to default (null)
					poi = null;
					return;
				}
				
			}
		}

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



