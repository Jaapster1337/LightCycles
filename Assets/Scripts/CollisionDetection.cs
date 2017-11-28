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
		if(other.gameObject.tag == "Powerup")
		{			
			gc.PowerUp();
			Destroy(other.gameObject);
		}
		else if (other.gameObject.tag == "Boundary")
		{		
			
			if(transform.localEulerAngles.z == 0)
			{
				transform.position = new Vector3(transform.position.x,-80.0f,0.0f);
				transform.Translate(Vector2.up * gc.mSpeed);
			}
			print(transform.localEulerAngles.z);

			//gc.setAtOppositeBoundary();

		}
		else if(other.gameObject.tag != gameObject.tag)
		{
			gc.GameOver();
		}
	}
}
