using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
	public float lifetime;
	public float wallColTimer;
	public float timer;
	public bool isActive;
	private GameController gc;

	void Start () {

		Destroy (gameObject, lifetime);
		timer = 0.0f;
		isActive = false;
		gc = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
	}

	void Update()
	{
		if(!isActive && !gc.pause)
		{
			if(timer >= wallColTimer)
			{
				isActive = true;
			} 
			else
			{
				
				timer += 1 * Time.deltaTime;

			}
		}
	}
}

