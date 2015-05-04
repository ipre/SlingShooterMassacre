using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	// Inspector variable
	public GameObject prefabProjectile;

	// Internal state variable
	private GameObject launchPoint;
	private bool aimingMode;
	private float maxMagnitude;
	private Vector3 mouseDelta;

	private GameObject projectile;
	private Vector3 launchPos;

	void Awake(){
		Transform launchPointTrans = transform.Find ("Launchpoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPointTrans.position;
	}

	void OnMouseEnter(){
		print ("Slingshot:Enter");	
		launchPoint.SetActive (true);
	//	launchPoint.transform.position = Input.mousePosition
	}

	void OnMouseExit(){
		print ("Slingshot:Exit");
		launchPoint.SetActive (false);
	}

	void OnMouseDown() {

		// Set the game aiming mode
		aimingMode = true;

		// Instatiate a projectile at LaunchPoint
		projectile = Instantiate (prefabProjectile) as GameObject;

		// Turn off physics for aiming mode	
		projectile.GetComponent<Rigidbody>().isKinematic = true; 

		// Set position of projectile to mousePosition
		projectile.transform.position = launchPos;
	}



	void Update() {

		// Check for aiming mode
		if(aimingMode){

			launchPoint.SetActive ( true ) ;
			// Get mouse position and convert to 3d
			Vector3 mousePos2D = Input.mousePosition;
			mousePos2D.z = - Camera.main.transform.position.z;
			mousePos2D = Camera.main.ScreenToWorldPoint(mousePos2D);

			// Calculate the delata between launch position and mouse position
			mouseDelta = mousePos2D - launchPos;

			// Comnstrain the dealta to the radius of the sphere collider
			maxMagnitude = this.GetComponent<SphereCollider>().radius - projectile.GetComponent<SphereCollider>().radius;
			mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxMagnitude);

			// Set projectile position to new position and fire it
			projectile.transform.position = launchPos + mouseDelta;
		}
	}

	void OnMouseUp () {
		aimingMode=false;
		projectile.GetComponent<Rigidbody>().isKinematic = false; 
		//projectile.GetComponent<Rigidbody>().AddForce(-mouseDelta*1000);
		projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * 10;
	}
}
