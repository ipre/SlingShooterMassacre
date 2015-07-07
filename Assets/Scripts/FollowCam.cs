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


	void Awake() {
		S = this;
		CamZ = transform.position.z;
		startPos = GameObject.FindGameObjectWithTag("Slingshot");
	}

	void FixedUpdate() {

		Vector3 destination = poi.transform.position;

		if(poi.CompareTag("Slingshot")){
			destination = startPos.transform.position;
			//transform.position = startPos.transform.position;

		}

		else{
			
		if(poi.CompareTag("Projectile")){
				destination = poi.transform.position;
			if(poi.GetComponent<Rigidbody>().IsSleeping()){
					poi = startPos;
					//destination = startPos.transform.position;
				print ("sleep");

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

}
