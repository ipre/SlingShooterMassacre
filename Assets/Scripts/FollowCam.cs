using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public GameObject poi;
	public static FollowCam S; //Singleton FollowCam instance
	//private Vector3 velocity = Vector3.zero;

	public Vector3 destination;
	private float CamZ;

	public float zoom = 1;
	public float easing = 0.05f;
	public Vector2 minXY;

	//delay until camera changes targets
	//private float timer=0.0f;

	//camera shake
	private static float shake;
	public float shakeAmount = 3.5f;
	public float decreaseFactor = 1.5f;


	void Awake() {
		S = this;
		CamZ = transform.position.z;
	}

	void FixedUpdate() {	

		if (shake > 0) {
			S.transform.localPosition = new Vector3 (transform.localPosition.x + Random.insideUnitCircle.x * shakeAmount,S.transform.localPosition.y + Random.insideUnitCircle.y * shakeAmount, transform.position.z) ;
			shake -= Time.deltaTime * decreaseFactor;

		} else {
			shake = 0.0f;
		}
			
		// Check if the poi exists
		if (poi == null) {
			destination = Vector3.zero;	
			/* 
			//set the destination to the slingshot (zero  vector)
			//delay for camera switch - not used anymore
			timer+= 1.0f * Time.deltaTime;
			if(timer>1.0f){
 			}
			*/
		} else {

			// else (there is a poi)			
			destination = poi.transform.position;
		}	
			// is the poi a projectile ? - not needed anymore
			/*
			 * if(poi.tag == "Projectile") {
			 * 
				//timer = 0;
					
				 check if it is resting (sleeping) - no need since projectile destroy themselves
				if(poi.GetComponent<Rigidbody>().IsSleeping()  ){

					// set the poi to default (null) - destroy themselves = null
					poi = null;
					return;
					}
				
				}
		 		*/
			

		destination.z = CamZ;
		destination.x = Mathf.Max(minXY.x, destination.x);
		destination.y = Mathf.Max(minXY.y, destination.y);
		
		//transform.position = destination;
		//transform.position = Vector3.SmoothDamp(transform.position,destination,ref velocity,0.9f);
		transform.position = Vector3.Lerp (transform.position, destination, easing);
		this.GetComponent<Camera>().orthographicSize = 10 + destination.y;
		this.GetComponent<Camera>().orthographicSize = 10 + transform.position.y;
	}

	public static void Shake(float init){
		shake = .35f;
	}
}



