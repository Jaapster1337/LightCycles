using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	//private GameController gameController;
	GameController gc;

	// Use this for initialization
	void Start () {
		gc = gameObject.GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Boundary")
		{		
			float rotation = transform.localEulerAngles.z;
			gc.setAtOppositeBoundary(rotation);
		}
		 if(other.gameObject.tag == "Powerup")
		{			
			gc.PowerUp();
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Player" || other.gameObject.tag =="Player2")
		{
			gc.GameOver();
		}
	}
}
