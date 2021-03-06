﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour {

	// Inspector variable
	public GameObject prefabProjectile;
    public float power=5;
    public AimSystem aimSys;

	// Internal state variable
	private GameObject launchPoint;
	private bool aimingMode;
	private float maxMagnitude;
	private Vector3 mouseDelta;

	private GameObject projectile;
	private Vector3 launchPos;

	//blendshape
	private GameObject cannon;
	private SkinnedMeshRenderer cannonShape;
	private float cannonLerp;
	private bool cannonActive;

	//audio
	private AudioSource source;
	public AudioClip ShootAudio;

    //Gamecontroller
    public GameController gc;

    //Slider
    public Slider sl;

    

	void Awake(){
		Transform launchPointTrans = transform.Find ("Launchpoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPointTrans.position;
		cannon = GameObject.Find("cannon");
		cannonShape = cannon.GetComponent<SkinnedMeshRenderer>();
		source = GetComponent<AudioSource> ();
  
	}

	void OnMouseEnter(){
		//print ("Slingshot:Enter");
		cannonActive = true;
		launchPoint.SetActive (true);
	//	launchPoint.transform.position = Input.mousePosition
	}

	void OnMouseExit(){
		//print ("Slingshot:Exit");
		launchPoint.SetActive (false);
		if(!aimingMode)
		cannonActive = false;

	}

	void OnMouseDown() {

		// Set the game aiming mode
		aimingMode = true;
		cannonActive = true ;
		// Instatiate a projectile at LaunchPoint
		projectile = Instantiate (prefabProjectile) as GameObject;

		// Turn off physics for aiming mode	
		projectile.GetComponent<Rigidbody>().isKinematic = true; 
		projectile.GetComponent<MeshRenderer> ().enabled = false;
        projectile.GetComponent<TrailRenderer>().enabled = false;
		// Set position of projectile to mousePosition
		projectile.transform.position = launchPos;
        gc.SwitchView("Both");
	}



	void Update() {

		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = - Camera.main.transform.position.z;
		mousePos2D = Camera.main.ScreenToWorldPoint(mousePos2D);
		mouseDelta = mousePos2D - launchPos;
		float cannonRot = -Mathf.Atan2(mouseDelta.x, mouseDelta.y) * Mathf.Rad2Deg;
		// Check for aiming mode

		if(aimingMode){
			float blend = mouseDelta.magnitude - 2f;
			cannonActive = true;
			launchPoint.SetActive ( true ) ;
			// Get mouse position and convert to 3d
			cannonShape.SetBlendShapeWeight(0, Mathf.Lerp (cannonShape.GetBlendShapeWeight(0),blend*35f,0.35f));
			cannon.transform.rotation = Quaternion.Euler (0,0,cannonRot);
			// Calculate the delata between launch position and mouse position


			// Comnstrain the dealta to the radius of the sphere collider
			maxMagnitude = this.GetComponent<SphereCollider>().radius - projectile.GetComponent<SphereCollider>().radius;
			mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxMagnitude);

			// Set projectile position to new position and fire it
			projectile.transform.position = launchPos + mouseDelta;

            //Linerenderer
            aimSys.UpdateTraj(mouseDelta * power, launchPos+mouseDelta,power);
		}
		//blendshape calculation based on mouse position
		else if(cannonActive){
			cannon.transform.rotation = Quaternion.Lerp (cannon.transform.rotation,Quaternion.Euler(0,0,cannonRot),0.1f);
		}else{
			cannonShape.SetBlendShapeWeight(0, Mathf.Lerp (cannonShape.GetBlendShapeWeight(0),0f,0.15f));
			cannon.transform.rotation = Quaternion.Lerp (cannon.transform.rotation,Quaternion.Euler(0,0,0),0.01f);
		}
	}

	void OnMouseUp () {
		aimingMode=false;
		cannonActive = false;
        projectile.GetComponent<TrailRenderer>().enabled = true;
		projectile.GetComponent<MeshRenderer> ().enabled = true;
		projectile.GetComponent<Rigidbody>().isKinematic = false; 
		//projectile.GetComponent<Rigidbody>().AddForce(-mouseDelta*1000);
        projectile.GetComponent<Rigidbody>().velocity = mouseDelta * power;
		FollowCam.S.poi = projectile;
		GameController.ShotFired();
		//added code
		source.PlayOneShot (ShootAudio);
		FollowCam.Shake (.8f);
	}

    public Vector3 getVelocity(){
        return mouseDelta*power;
    }

    public void setPower()
    {
        power =sl.value;
    }
}
