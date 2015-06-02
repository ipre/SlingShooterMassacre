using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public GameObject poi;
	public static FollowCam S; //Singleton FollowCam instance
	//private Vector3 velocity = Vector3.zero;

	private float CamZ;
	public float zoom = 1;
	public float easing = 0.05f;
	public GameObject startPos;
	public Vector2 minXY;


	void Awake() {
		S = this;
		CamZ = transform.position.z;
		GameObject startPos = GameObject.Find("Slingshot");
	}

	void FixedUpdate() {
		if(poi == null){
			poi=startPos;
			print ("reset");
		}
		if(poi!=null){

		Vector3 destination = poi.transform.position;
			if(poi.CompareTag("Projectile")){
				if(poi.GetComponent<Rigidbody>().IsSleeping()){
				poi = null;
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
			print ("movecam");
		}
	}
}
