using UnityEngine;
using System.Collections;

public class ProjectileTrail : MonoBehaviour {

	public static ProjectileTrail S;
	public float minDist = 0.1f;

	private LineRenderer line;

	private GameObject _poi;

	private Vector3 lastPoint;

	private int pointsCount;


	public GameObject poi {
		get{
			return _poi;
		}

		set{
			_poi = value;

			//check if the poi is set to something and now to something new

			// reset the whole linerenderer thingy
			if(poi!= null) { 
				line.enabled = false;
				pointsCount = 0;
				line.SetVertexCount (0);
			}
		}
	}

	void Awake() {
		S = this;
		line = GetComponent<LineRenderer>();

		//intitialize stuff
		pointsCount = 0;
		line.enabled = false;

	}

	void FixedUpdate() {

		// is there a poi

		// if not , try using the camera poit ( it is a projectile )

		// at this point the poi has a value and its a projectile

		AddPoint();
	}

	public void AddPoint(){
		Vector3 pt = _poi.transform.position;

		if(pointsCount > 0 && ( pt - lastPoint).magnitude < minDist) {
			return;
		}

		if(pointsCount == 0){
			line.enabled = true;
		}

		pointsCount++;
		line.SetVertexCount(pointsCount);
		line.SetPosition(pointsCount - 1,pt);

		lastPoint = pt;
		//if the point isnt far enough from the last point do nothing

		// if out curent point is the first point ( launch ); add first point

		// else its not the first point; add another point to the line renderer




		lastPoint = pt;
	}
}
