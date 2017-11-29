using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

	//private GameController gameController;
	GameController gc;
	Mover mv;

	// Use this for initialization
	void Start () {
		gc = gameObject.GetComponent<GameController>();
		mv = gameObject.GetComponent<Mover>();
	}

	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter2D(Collider2D other){
		//print(other.name +" "+ gameObject.name);
		if(other.gameObject.tag == "Boundary")
		{		
			float rotation = transform.localEulerAngles.z;
			mv.SetAtOppositeBoundary(rotation);
		}
		 if(other.gameObject.tag == "Powerup")
		{			
			gc.PowerUp();
			Destroy(other.gameObject);
		}

		if(other.gameObject.tag == "Playerwall" && other.gameObject.GetComponent<DestroyByTime>().isActive)
		{
			gc.GameOver();
		}
	}
}
