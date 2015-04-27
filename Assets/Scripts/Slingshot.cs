using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	private GameObject launchPoint;

	void Awake(){
		Transform launchPointTrans = transform.Find ("Launchpoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
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
}
