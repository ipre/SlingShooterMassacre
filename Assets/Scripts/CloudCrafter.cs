using UnityEngine;
using System.Collections;

public class CloudCrafter : MonoBehaviour {

	public int numClouds = 40 ; 

	public Vector3 cloudPosMin;
	public Vector3 cloudPosMax;

	public float cloudScaleMin = 1.0f;
	public float cloudScaleMax = 5.0f;

	public float cloudSpeedMult = 0.5f;
	public GameObject CloudAnchor;

	public GameObject[] CloudPrefabs;

	//internal fields
	private GameObject[] cloudInstances;

	void Awake(){
		/*
		 * create array
		 * find the cloud anchor in hierarchi
		 * iterate through array and create a cloud forr each slot
		 * 
		 * randomly pick one of the cloud prefabs
		 * create that instance
		 * position and scale the cloud randomly
		 * apple the changes to our instance
		 * make the cloud a child of our anchor
		 * 
		 *put the cloud into our instances array

		*/
		cloudInstances = new GameObject[numClouds];
		GameObject anchor = GameObject.Find("Clouds");
		GameObject cloud;


		for(int i = 0 ; i<numClouds; i++){

			int random = Random.Range(0,5);

			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp(cloudScaleMin,cloudScaleMax,scaleU);

			Vector3 cPos = anchor.transform.position;
			cPos.x = Random.Range(cloudPosMin.x,cloudPosMax.x);
			cPos.y = Random.Range(cloudPosMin.y,cloudPosMax.y);
			cPos.y = Mathf.Lerp(cloudPosMin.y , cPos.y, scaleU);
			cPos.z = 100-90*scaleU;

			cloud = Instantiate (CloudPrefabs[random]) as GameObject;  

			cloud.transform.position = cPos;
			cloud.transform.localScale = Vector3.one * scaleVal;

			cloud.transform.parent = anchor.transform;

			cloudInstances[i] = cloud;
		}
	}

	void Update(){
		// Iterate through all cloud instance
		foreach(GameObject cloud in cloudInstances){
		// Get the position and scale
			float scaleVal = cloud.transform.localScale.x;
			Vector3 cPos = cloud.transform.position;

			cPos.x -= Time.deltaTime * cloudSpeedMult * scaleVal;
		// Check if cloud x pos is too small - if it is set it to maximum x pos
			if(cPos.x < cloudPosMin.x){
				cPos.x = cloudPosMax.x;
			}
			//cloud.transform.position = cPos;
		}
	}
}
