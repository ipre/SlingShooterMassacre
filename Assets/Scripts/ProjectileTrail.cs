using UnityEngine;
using System.Collections;

public class ProjectileTrail : MonoBehaviour {
	public static ProjectileTrail S;

	public float minDistance = 0.1f;

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
		}
	}

	void Awake() {
		S = this;
		line = GetComponent<LineRenderer>();

		//intitialize stuff
	}

	void FixedUpdate() {

		// is there a poi

		// if not , try using the camera poit ( it is a projectile )

		// at this point the poi has a value and its a projectile

		AddPoint();
	}

	void AddPoint(){
		Vector3 pt = _poi.transform.position;

		//if the point isnt far enough from the last point do nothing

		// if out curent point is the first point ( launch ); add first point

		// else its not the first point; add another point to the line renderer




		lastPoint = pt;
	}
}
