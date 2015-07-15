using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

         private Camera camera;
        private Vector3 previousCameraTransform;
        public float parallaxV;

	// Use this for initialization
	void Start () {
	    camera = Camera.main;
        previousCameraTransform = camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 delta = camera.transform.position - previousCameraTransform;
        delta.y *= 0.2f;
        delta.z = 0 ;
        transform.position += delta / parallaxV;

        previousCameraTransform = camera.transform.position;
	
	}
}
