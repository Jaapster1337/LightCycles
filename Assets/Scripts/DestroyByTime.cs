using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
	public float lifetime;
	public float wallColTimer;
	public float timer;
	private bool isActive;

	void Start () {

		Destroy (gameObject, lifetime);
		timer = 0.0f;
		isActive = false;
	}

	void Update()
	{
		if(!isActive)
		{
			if(timer >= wallColTimer)
			{
				isActive = true;
				gameObject.tag = "Boundary";
			} 
			else
			{
				
				timer += 1 * Time.deltaTime;

			}
		}
	}
}

