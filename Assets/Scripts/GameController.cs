using UnityEngine;
using System.Collections;
using UnityEngine.UI;

enum GameState { 
	idle,
	playing,
	levelEnd
}

public class GameController : MonoBehaviour {

	public static GameController S;


	//public inspector fields
	public GameObject[] castles;
	public Vector3 castlePos;

	public Text gtLevel;
	public Text gtShots;

	//internal fields
	private int level;
	private int levelMax;

	private int shotsTaken;

	private GameObject castle;

	private string showing = "Slingshot";

	private GameState state = GameState.idle;


	void Awake() {
		S = this;

		level = 0 ;
		levelMax = castles.Length;

		StartLevel();
	
	}


	public void Update() {
		//update gui text

		// check for lvl end
	}


	public void SwitchView(string view){
		print (view);

		//switch over all possibilities slingshot/both/castles

		//set the followcams POI to the according value

	}


	public void StartLevel(){
		// if there is a castle, destroy it
		//destroy all remaining projectiles
		//instantiate a new castle

		//switch view to both
		//clear all projectile lines(trail)
	}


}
