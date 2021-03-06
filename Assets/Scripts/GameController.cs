﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//public KeyCode upKey;
	//public KeyCode downKey;
	//public KeyCode leftKey;
	//public KeyCode rightKey;
	//public Rigidbody2D rb2d;
	//public float mSpeed = 32;


	public GameObject wallPrefab;
	public GameObject otherPlayer;
	public GameObject powerUp;
	public GameObject[] powerUps;
	public Text gameOverText;
	public Text restartText;
	public Text quitText;
	public bool gameOver = false;
	public bool restart = false;
	public bool pause=false;
	public AudioClip deathSound;
	public AudioClip PoPickUp;
	Mover mv;
	SoundController sc;

	// Use this for initialization
	void Start () {
		mv = gameObject.GetComponent<Mover>();
		mv.rb2d = GetComponent<Rigidbody2D>();
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,180f);
		mv.rb2d.velocity = Vector2.down * mv.mSpeed;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		quitText.text = "";
		InvokeRepeating("SpawnPowerUp", 1f, 10f);		
		
	}
	
	// Update is called once per frame
	void Update () {
		mv.Move();

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if(gameOver)
		{
			restartText.text = "Press any key for Restart";

			if(Input.anyKeyDown)
			{
				SceneManager.LoadScene("lightcycles");
				SceneManager.SetActiveScene(SceneManager.GetSceneByName("lightcycles"));
			}
		}
		else if(!pause)
		{

			SpawnWall();

		}
	}

	public void SpawnWall()
	{	
		GameObject g = GameObject.Instantiate(wallPrefab, transform.position, Quaternion.identity);
		Collider2D wall = g.GetComponent<Collider2D>();
	}

	public void GameOver()
	{
		
		gameOverText.text = "Game Over";
		restartText.text = "Press any key to restart!";
		quitText.text = "Esc to quit";
		mv.rb2d.velocity = Vector2.zero;
		AudioSource.PlayClipAtPoint(deathSound,transform.position);
		otherPlayer.GetComponent<GameController>().Pause();
		gameOver = true;


	}

	public void Pause()
	{
		pause = true;
		mv.rb2d.velocity = Vector2.zero;
	}

	public void PowerUp()
	{		
		mv.mSpeed = mv.mSpeed * 2;
		AudioSource.PlayClipAtPoint(PoPickUp,transform.position);
	}

	public void SpawnPowerUp()
	{
		powerUps = GameObject.FindGameObjectsWithTag("Powerup"); 
		if(powerUps.Length < 1)
		{

			Vector2 position = new Vector2(Random.Range(-35.0f, 35.0f), Random.Range(-35.0f, 35.0f));
			Collider2D hit = Physics2D.OverlapPoint(position);
			if(hit == null)
				Instantiate(powerUp, position, transform.rotation);
			

		}

	}
	public void SetAtOppositeBoundary(float rotation)  //x y z /y = vertical /x = horizontal
	{
		if(transform.localEulerAngles.z == 0)//if direction up
		{
			transform.position = new Vector3(transform.position.x,-80.0f,0.0f);//keep x set y
			transform.Translate(Vector2.up * mv.mSpeed);//give speed with direction
		} 
		if(transform.localEulerAngles.z == 90)//if direction left
		{
			transform.position = new Vector3(64.0f,transform.position.y + 16.0f,0.0f);//set x keep y
			transform.Translate(Vector2.left * mv.mSpeed);//give speed with direction
		}
		if(transform.localEulerAngles.z == 180)//direction down
		{
			transform.position = new Vector3(transform.position.x,48.0f,0.0f);//keep x set y
			transform.Translate(Vector2.down * mv.mSpeed);//give speed with direction);
		}
		if(transform.localEulerAngles.z == 270)//direction right
		{
			transform.position = new Vector3(-64.0f,transform.position.y + 16.0f,0.0f);//set x keep y
			transform.Translate(Vector2.right * mv.mSpeed);//give speed with direction
		}

	
	}
}
