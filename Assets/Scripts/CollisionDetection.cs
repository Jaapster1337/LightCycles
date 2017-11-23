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
		
//		

	}
		
	void OnTriggerEnter2D(Collider2D other){		
		if(other.gameObject.tag == "PowerUp")
		{			
			gc.GameOver();
		}
		else if (other.gameObject.tag == "Boundary")
		{			
			gc.GameOver();
		}
		else if(other.gameObject.tag != gameObject.tag)
		{
			gc.PowerUp();
		}
	}
}
