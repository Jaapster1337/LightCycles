using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public GameObject wallPrefab;
	public GameObject otherPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnWall()
	{	
		GameObject g = GameObject.Instantiate(wallPrefab, transform.position, Quaternion.identity);
	}
}
